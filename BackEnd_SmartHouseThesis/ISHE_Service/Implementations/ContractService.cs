using AutoMapper;
using AutoMapper.QueryableExtensions;
using ISHE_Data;
using ISHE_Data.Entities;
using ISHE_Data.Models.Requests.Filters;
using ISHE_Data.Models.Requests.Get;
using ISHE_Data.Models.Requests.Post;
using ISHE_Data.Models.Requests.Put;
using ISHE_Data.Models.Views;
using ISHE_Data.Repositories.Interfaces;
using ISHE_Service.Interfaces;
using ISHE_Utility.Constants;
using ISHE_Utility.Enum;
using ISHE_Utility.Exceptions;
using ISHE_Utility.Helpers.Utils;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using static ISHE_Utility.Helpers.FormatDate.FormatDate;

namespace ISHE_Service.Implementations
{
    public class ContractService : BaseService, IContractService
    {
        private readonly IContractRepository _contract;
        private readonly IContractDetailRepository _contractDetail;
        private readonly IDevicePackageUsageRepository _devicePackageUsage;
        private readonly IPaymentRepository _payment;
        private readonly ISmartDeviceRepository _smartDevice;
        private readonly IDevicePackageRepository _devicePackage;
        private readonly IStaffAccountRepository _staffAccount;
        private readonly ISurveyRequestRepository _surveyRequest;
        private readonly ISurveyRepository _survey;
        private readonly ICloudStorageService _cloudStorageService;

        private readonly IPaymentService _paymentService;

        public ContractService(IUnitOfWork unitOfWork, IMapper mapper, IPaymentService paymentService, ICloudStorageService cloudStorageService) : base(unitOfWork, mapper)
        {
            _contract = unitOfWork.Contract;
            _contractDetail = unitOfWork.ContractDetail;
            _devicePackageUsage = unitOfWork.DevicePackageUsage;
            _payment = unitOfWork.Payment;
            _smartDevice = unitOfWork.SmartDevice;
            _devicePackage = unitOfWork.DevicePackage;
            _staffAccount = unitOfWork.StaffAccount;
            _surveyRequest = unitOfWork.SurveyRequest;
            _survey = unitOfWork.Survey;
            _paymentService = paymentService;
            _cloudStorageService = cloudStorageService;
        }


        public async Task<ListViewModel<PartialContractViewModel>> GetContracts(ContractFilterModel filter, PaginationRequestModel pagination)
        {
            var query = _contract.GetAll();

            if (filter.StaffId.HasValue)
            {
                query = query.Where(contract => contract.StaffId.Equals(filter.StaffId.Value)
                                    || contract.Staff.InverseStaffLead.Any(staff => staff.AccountId == filter.StaffId));
            }

            if (filter.CustomerId.HasValue)
            {
                query = query.Where(contract => contract.CustomerId.Equals(filter.CustomerId.Value));
            }

            if (!string.IsNullOrEmpty(filter.Status.ToString()))
            {
                query = query.Where(contract => contract.Status.Equals(filter.Status.ToString()));
            }

            var totalRow = await query.AsNoTracking().CountAsync();
            var paginatedQuery = query
                .OrderByDescending(sv => sv.CreateAt)
                .Skip(pagination.PageNumber * pagination.PageSize)
                .Take(pagination.PageSize);

            var contracts = await paginatedQuery
                .ProjectTo<PartialContractViewModel>(_mapper.ConfigurationProvider)
                .AsNoTracking()
                .ToListAsync();
            return new ListViewModel<PartialContractViewModel>
            {
                Pagination = new PaginationViewModel
                {
                    PageNumber = pagination.PageNumber,
                    PageSize = pagination.PageSize,
                    TotalRow = totalRow
                },
                Data = contracts
            };
        }

        public async Task<ContractViewModel> GetContract(string id)
        {
            return await _contract.GetMany(contract => contract.Id.Equals(id))
                .ProjectTo<ContractViewModel>(_mapper.ConfigurationProvider)
                .FirstOrDefaultAsync() ?? throw new NotFoundException("Không tìm thấy contract");
        }

        public async Task<ContractViewModel> CreateContract(CreateContractModel model)
        {
            var result = 0;
            var contractId = string.Empty;
            using (var transaction = _unitOfWork.Transaction())
            {
                try
                {

                    var customerId = await GetCustomer(model.SurveyId);
                    contractId = GenerateContractId();
                    var priceOfDevice = await CreateContractDetail(contractId, model.ContractDetails, false);
                    var (priceOfPackage, totalMonth) = await CreateDevicePackageUsage(contractId, model.DevicePackages, false);

                    var startPlanDate = CheckFormatDate(model.StartPlanDate.ToString());
                    var endPlanDate = startPlanDate.AddMonths(totalMonth);
                    await CheckStaff(model.StaffId, startPlanDate, endPlanDate);

                    var contract = new Contract
                    {
                        Id = contractId,
                        SurveyId = model.SurveyId,
                        StaffId = model.StaffId,
                        TellerId = model.TellerId,
                        CustomerId = customerId,
                        Title = model.Title,
                        Description = model.Description,
                        Deposit = model.Deposit,
                        StartPlanDate = startPlanDate,
                        EndPlanDate = endPlanDate,
                        Status = ContractStatus.PendingDeposit.ToString(),
                        TotalAmount = priceOfDevice + priceOfPackage,
                    };
                    _contract.Add(contract);

                    result = await _unitOfWork.SaveChanges();
                    transaction.Commit();
                }
                catch (Exception)
                {
                    transaction.Rollback();
                    throw;
                }
            };
            return result > 0 ? await GetContract(contractId) : null!;
        }

        public async Task<ContractViewModel> UpdateContract(string id, UpdateContractModel model)
        {
            var contract = await _contract.GetMany(con => con.Id.Equals(id))
                .Include(contract => contract.ContractDetails)
                .Include(contract => contract.DevicePackageUsages)
                .FirstOrDefaultAsync() ?? throw new NotFoundException("Không tìm thấy contract");

            

            if (!string.IsNullOrEmpty(model.Status))
            {
                var flag = IsValidStatus(contract.Status, model.Status);

                if (flag)
                {
                    contract.Status = model.Status;
                }
                else
                {
                    throw new BadRequestException($"Không thể cập nhật trạng thái từ {contract.Status} thành {model.Status}");
                }
                //await CheckToCreatePayment(id, contract.Status);
            }

            if(model.Image != null)
            {
                contract.ImageUrl = await UploadContractImage(id, model.Image);
            }

            

            contract.Title = model.Title ?? contract.Title;
            contract.Description = model.Description ?? contract.Description;
            contract.Deposit = model.Deposit ?? contract.Deposit;
            contract.ActualStartDate = model.ActualStartDate ?? contract.ActualStartDate;
            contract.ActualEndDate = model.ActualEndDate ?? contract.ActualEndDate;

            var totalPackagePrice = (int)contract.DevicePackageUsages.Sum(usage => usage.DiscountAmount.HasValue ? usage.Price * (100 - usage.DiscountAmount) / 100 : usage.Price)!;
            var totalDevicePrice = contract.ContractDetails
                .Where(detail => detail.Type.Equals(ContractDetailType.Purchase))
                .Sum(detail => (detail.Price + detail.InstallationPrice) * detail.Quantity);

            if (model.StaffId.HasValue)
            {
                await CheckStaff(model.StaffId.Value, contract.StartPlanDate, contract.EndPlanDate);
                contract.StaffId = model.StaffId.Value;
            }

            if (model.ContractDetails != null && model.ContractDetails.Count > 0)
            {
                totalDevicePrice = await CreateContractDetail(id, model.ContractDetails, true);
            }


            if (model.DevicePackages != null && model.DevicePackages.Count > 0)
            {
                var (totalPrice, totalMonth) = await CreateDevicePackageUsage(id, model.DevicePackages, true);
                contract.EndPlanDate = contract.StartPlanDate.AddMonths(totalMonth);
                totalPackagePrice = totalPrice;
            }


            contract.TotalAmount = totalPackagePrice + totalDevicePrice;

            _contract.Update(contract);
            var result = await _unitOfWork.SaveChanges();
            return result > 0 ? await GetContract(id) : null!;
        }

        //PRIVATE METHOD
        private async Task<string> UploadContractImage(string contractId, IFormFile image)
        {
            if (!image.ContentType.StartsWith("image/"))
            {
                throw new BadRequestException("File không phải là hình ảnh");
            }

            await _cloudStorageService.DeleteContract(contractId);

            var url = await _cloudStorageService.UploadContract(contractId, image.ContentType, image.OpenReadStream());
            return url;
        }

        private async Task CheckStaff(Guid staffId, DateTime startDate, DateTime endDate)
        {
            var staff = await _staffAccount.GetMany(s => s.AccountId.Equals(staffId))
                .FirstOrDefaultAsync() ?? throw new BadRequestException("Không tìm thấy staff");
            if (!staff.IsLead)
            {
                throw new BadRequestException("Staff được chọn chưa phù hợp");
            }

            var overlappingContracts = await _contract.GetMany(c => c.StaffId == staffId &&
                                                    c.StartPlanDate <= endDate && c.EndPlanDate >= startDate)
                                                        .ToListAsync();
            if (overlappingContracts.Any())
            {
                throw new BadRequestException("Staff đã được giao hợp đồng trong khoảng thời gian này");
            }
        }

        private async Task CheckToCreatePayment(string contractId, string contractStatus)
        {
            var createPayment = new CreatePaymentModel
            {
                ContractId = contractId,
                TypePayment = PaymentType.Deposit
            };

            if (contractStatus == ContractStatus.DepositPaid.ToString())
            {
                await _paymentService.ProcessCashPayment(createPayment);
            }
            else if (contractStatus == ContractStatus.Completed.ToString())
            {
                createPayment.TypePayment = PaymentType.Completion;
                await _paymentService.ProcessCashPayment(createPayment);
            }
        }

        private async Task<Guid> GetCustomer(Guid surveyId)
        {
            var survey = await _survey.GetMany(sur => sur.Id.Equals(surveyId))
                .Include(sur => sur.SurveyRequest)
                .FirstOrDefaultAsync() ?? throw new NotFoundException("Không tìm thấy survey");

            survey.Status = SurveyStatus.Completed.ToString();
            _survey.Update(survey);

            return survey.SurveyRequest.CustomerId;
        }

        private async Task<int> CreateContractDetail(string contractId, List<SmartDevices> details, bool IsUpdate)
        {
            var totalAmount = 0;

            if (IsUpdate)
            {
                var existingDetails = await _contractDetail.GetMany(detail => detail.ContractId.Equals(contractId)
                                                                    && detail.Type.Equals(ContractDetailType.Purchase))
                                                            .ToListAsync();
                _contractDetail.RemoveRange(existingDetails);
            }
            //PURCHASE
            foreach (var item in details)
            {
                var device = await _smartDevice.GetMany(device => device.Id.Equals(item.SmartDeviceId))
                    .FirstOrDefaultAsync() ?? throw new NotFoundException($"Không tìm thấy smart device với id: {item.SmartDeviceId}");

                var quantity = item.Quantity.GetValidOrDefault(1);
                var totalPrice = (device.Price + device.InstallationPrice) * quantity;

                var detail = new ContractDetail
                {
                    Id = Guid.NewGuid(),
                    ContractId = contractId,
                    SmartDeviceId = item.SmartDeviceId,
                    Name = device.Name,
                    Type = ContractDetailType.Purchase,
                    Price = device.Price,
                    InstallationPrice = device.InstallationPrice,
                    Quantity = quantity,
                    IsInstallation = true,
                };

                _contractDetail.Add(detail);

                totalAmount += totalPrice;
            }

            return totalAmount;
        }

        private async Task<(int, int)> CreateDevicePackageUsage(string contractId, List<Guid> devicePackageIds, bool IsUpdate)
        {
            var totalAmount = 0;
            var totalMonthToCompleted = 0;

            if (IsUpdate)
            {
                var existingPackage = await _devicePackageUsage.GetMany(package => package.ContractId.Equals(contractId)).ToListAsync();
                _devicePackageUsage.RemoveRange(existingPackage);

                var existingDevice = await _contractDetail.GetMany(device => device.ContractId.Equals(contractId)
                                                                    && device.Type.Equals(ContractDetailType.Package))
                                                            .ToListAsync();
                _contractDetail.RemoveRange(existingDevice);
            }

            foreach (var devicePackageId in devicePackageIds)
            {
                var package = await _devicePackage.GetMany(pac => pac.Id.Equals(devicePackageId))
                    .Include(pac => pac.Promotion)
                    .Include(pac => pac.SmartDevicePackages)
                        .ThenInclude(smart => smart.SmartDevice)
                    .FirstOrDefaultAsync() ?? throw new NotFoundException($"Không tìm thấy device package với id: {devicePackageId}");

                totalAmount += package.Price;
                var discountAmount = package.Promotion?.DiscountAmount;
                if (discountAmount.HasValue)
                {
                    totalAmount *= (100 - discountAmount.Value) / 100;
                }

                totalMonthToCompleted += package.CompletionTime;

                var devicePackageUsage = new DevicePackageUsage
                {
                    Id = Guid.NewGuid(),
                    ContractId = contractId,
                    DevicePackageId = devicePackageId,
                    DiscountAmount = discountAmount,
                    Price = package.Price,
                    WarrantyDuration = package.WarrantyDuration
                };
                _devicePackageUsage.Add(devicePackageUsage);



                foreach (var device in package.SmartDevicePackages)
                {
                    var detail = new ContractDetail
                    {
                        Id = Guid.NewGuid(),
                        ContractId = contractId,
                        SmartDeviceId = device.SmartDeviceId,
                        Name = device.SmartDevice.Name,
                        Type = ContractDetailType.Package,
                        Price = device.SmartDevice.Price,
                        Quantity = device.SmartDeviceQuantity,
                        IsInstallation = true
                    };
                    _contractDetail.Add(detail);
                }
            }

            return (totalAmount, totalMonthToCompleted);
        }

        private bool IsValidStatus(string currentStatus, string newStatus)
        {
            switch (currentStatus)
            {
                case nameof(ContractStatus.PendingDeposit):
                    return false;
                    //return newStatus == nameof(ContractStatus.DepositPaid);
                case nameof(ContractStatus.DepositPaid):
                    return newStatus == nameof(ContractStatus.InProgress);
                case nameof(ContractStatus.InProgress):
                    return newStatus == nameof(ContractStatus.WaitForPaid) || newStatus == nameof(ContractStatus.Cancelled);
                case nameof(ContractStatus.WaitForPaid):
                    return false;
                    //return newStatus == nameof(ContractStatus.Completed) || newStatus == nameof(ContractStatus.Cancelled);
                case nameof(ContractStatus.Completed):
                case nameof(ContractStatus.Cancelled):
                    return false;
                default:
                    return false;
            }
        }

        private static string GenerateContractId()
        {
            long ticks = DateTime.UtcNow.Ticks;
            int hash = HashCode.Combine(ticks);
            uint positiveHash = (uint)hash & 0x7FFFFFFF;
            string hashString = positiveHash.ToString("X8");
            string id = "HD" + hashString;

            return id;
        }
    }
}
