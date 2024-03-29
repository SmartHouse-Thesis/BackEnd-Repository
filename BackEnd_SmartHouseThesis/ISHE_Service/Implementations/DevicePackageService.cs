﻿using AutoMapper;
using ISHE_Data.Entities;
using ISHE_Data.Models.Requests.Filters;
using ISHE_Data.Models.Requests.Get;
using ISHE_Data.Models.Requests.Post;
using ISHE_Data.Models.Requests.Put;
using ISHE_Data.Models.Views;
using ISHE_Data.Repositories.Interfaces;
using ISHE_Data;
using ISHE_Service.Interfaces;
using ISHE_Utility.Enum;
using ISHE_Utility.Exceptions;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using AutoMapper.QueryableExtensions;

namespace ISHE_Service.Implementations
{
    public class DevicePackageService : BaseService, IDevicePackageService
    {
        private readonly IDevicePackageRepository _packageRepository;
        private readonly ISmartDeviceRepository _deviceRepository;
        private readonly IManufacturerRepository _manufacturerRepository;
        private readonly IPromotionRepository _promotionRepository;
        private readonly IImageRepository _imageRepository;

        private readonly ICloudStorageService _cloudStorageService;

        public DevicePackageService(IUnitOfWork unitOfWork, IMapper mapper, ICloudStorageService cloudStorageService) : base(unitOfWork, mapper)
        {
            _packageRepository = unitOfWork.DevicePackage;
            _deviceRepository = unitOfWork.SmartDevice;
            _manufacturerRepository = unitOfWork.Manufacturer;
            _promotionRepository = unitOfWork.Promotion;
            _imageRepository = unitOfWork.Image;

            _cloudStorageService = cloudStorageService;
        }

        public async Task<ListViewModel<DevicePackageViewModel>> GetDevicePackages(DevicePackageFilterModel filter, PaginationRequestModel pagination)
        {
            var query = _packageRepository.GetAll();

            if (!string.IsNullOrEmpty(filter.Name))
            {
                query = query.Where(device => device.Name.Contains(filter.Name));
            }

            if (!string.IsNullOrEmpty(filter.Manufacturer))
            {
                query = query.Where(device => device.Manufacturer.Name.Contains(filter.Manufacturer));
            }

            if (!string.IsNullOrEmpty(filter.Status.ToString()))
            {
                query = query.Where(device => device.Status.Equals(filter.Status.ToString()));
            }

            if (filter.MinPrice.HasValue)
            {
                query = query.Where(device => device.Price >= filter.MinPrice.Value);
            }

            if (filter.MaxPrice.HasValue)
            {
                query = query.Where(device => device.Price <= filter.MaxPrice.Value);
            }

            var totalRow = await query.AsNoTracking().CountAsync();
            var paginatedQuery = query
                .OrderByDescending(device => device.CreateAt)
                .Skip(pagination.PageNumber * pagination.PageSize)
                .Take(pagination.PageSize);

            var devicePackages = await paginatedQuery
                .ProjectTo<DevicePackageViewModel>(_mapper.ConfigurationProvider)
                .AsNoTracking()
                .ToListAsync();
            return new ListViewModel<DevicePackageViewModel>
            {
                Pagination = new PaginationViewModel
                {
                    PageNumber = pagination.PageNumber,
                    PageSize = pagination.PageSize,
                    TotalRow = totalRow
                },
                Data = devicePackages
            };
        }

        public async Task<DevicePackageDetailViewModel> GetDevicePackage(Guid id)
        {
            return await _packageRepository.GetMany(device => device.Id.Equals(id))
                                            .ProjectTo<DevicePackageDetailViewModel>(_mapper.ConfigurationProvider)
                                            .FirstOrDefaultAsync() ?? throw new NotFoundException("Không tìm thấy device package");
        }

        public async Task<DevicePackageDetailViewModel> CreateDevicePackage(CreateDevicePackageModel model)
        {
            CheckImage(model.Image);

            var result = 0;
            var devicePackageId = Guid.Empty;
            using (var transaction = _unitOfWork.Transaction())
            {
                try
                {
                    var manufactureId = await CheckManufacturer(model.ManufacturerId);
                    var promotionId = await CheckPromotion(model.PromotionId);
                    var (totalPrice, smartDevices) = await GetSmartDevices(model.SmartDevicesIds);
                    devicePackageId = Guid.NewGuid();

                    var devicePackage = new DevicePackage
                    {
                        Id = devicePackageId,
                        ManufacturerId = manufactureId,
                        PromotionId = model.PromotionId,
                        Name = model.Name,
                        WarrantyDuration = model.WarrantyDuration,
                        Description = model.Description,
                        Price = totalPrice,
                        SmartDevices = smartDevices,
                        Status = DevicePackageStatus.Active.ToString(),
                    };

                    _packageRepository.Add(devicePackage);

                    await CreateDevicePackageImage(devicePackageId, model.Image, false);

                    result = await _unitOfWork.SaveChanges();

                    transaction.Commit();
                }
                catch (Exception)
                {
                    transaction.Rollback();
                    throw;
                }
            };

            return result > 0 ? await GetDevicePackage(devicePackageId) : null!;
        }

        public async Task<DevicePackageDetailViewModel> UpdateDevicePackage(Guid id, UpdateDevicePackageModel model)
        {
            var devicePackage = await _packageRepository.GetMany(device => device.Id.Equals(id)).Include(device => device.SmartDevices)
                .FirstOrDefaultAsync() ?? throw new NotFoundException("Không tìm thấy device package");

            if (model.ManufacturerId.HasValue)
            {
                var manufacturerId = await CheckManufacturer((Guid)model.ManufacturerId);
                devicePackage.ManufacturerId = manufacturerId;
            }

            if (model.Image != null)
            {
                CheckImage(model.Image);
                await CreateDevicePackageImage(id, model.Image, true);
            }

            if (model.SmartDevicesIds != null && model.SmartDevicesIds.Count > 0)
            {
                var (totalPrice, smartDevices) = await GetSmartDevices(model.SmartDevicesIds);
                devicePackage.SmartDevices.Clear();
                devicePackage.SmartDevices = smartDevices;
                devicePackage.Price = totalPrice;
            }

            devicePackage.Name = model.Name ?? devicePackage.Name;
            devicePackage.WarrantyDuration = model.WarrantyDuration ?? devicePackage.WarrantyDuration;
            devicePackage.Description = model.Description ?? devicePackage.Description;
            devicePackage.Status = model.Status ?? devicePackage.Status;

            _packageRepository.Update(devicePackage);

            var result = await _unitOfWork.SaveChanges();
            return result > 0 ? await GetDevicePackage(id) : null!;
        }

        //PRIVATE METHOD

        private async Task<Image> CreateDevicePackageImage(Guid devicePackageId, IFormFile image, bool isUpdate)
        {
            if (isUpdate)
            {
                var listImages = await _imageRepository.GetMany(image => image.DevicePackageId.Equals(devicePackageId)).ToListAsync();
                foreach (var img in listImages)
                {
                    await _cloudStorageService.Delete(img.Id);
                }
                _imageRepository.RemoveRange(listImages);
            }

            var imageId = Guid.NewGuid();
            var url = await _cloudStorageService.Upload(imageId, image.ContentType, image.OpenReadStream());
            var newImage = new Image
            {
                Id = imageId,
                DevicePackageId = devicePackageId,
                Url = url
            };

            _imageRepository.Add(newImage);
            return newImage;
        }

        private void CheckImage(IFormFile image)
        {
            if (!image.ContentType.StartsWith("image/"))
            {
                throw new BadRequestException("File không phải là hình ảnh");
            }
        }

        private async Task<Guid> CheckManufacturer(Guid id)
        {
            return (await _manufacturerRepository
                    .GetMany(manufacturer => manufacturer.Id.Equals(id))
                    .FirstOrDefaultAsync())?.Id ?? throw new NotFoundException("Không tìm thấy manufacturer");
        }

        private async Task<Guid> CheckPromotion(Guid? id)
        {
            if (id.HasValue)
            {
                return (await _promotionRepository
                    .GetMany(promotion => promotion.Id.Equals(id))
                    .FirstOrDefaultAsync())?.Id ?? throw new NotFoundException("Không tìm thấy promotion");
            }
            return Guid.Empty;
        }

        private async Task<(int, ICollection<SmartDevice>)> GetSmartDevices(List<Guid> smartDeviceIds)
        {
            int totalPrice = 0;
            var list = await _deviceRepository.GetMany(device => smartDeviceIds.Contains(device.Id)).ToListAsync();
            if (list.Count == 0)
            {
                throw new BadRequestException("Vui lòng nhập lại smart device id.");
            }
            totalPrice = list.Sum(device => device.Price);
            return (totalPrice, list);
        }

    }
}
