using AutoMapper;
using ISHE_Data.Models.Requests.Post;
using ISHE_Data.Models.Requests.Put;
using ISHE_Data.Models.Views;
using ISHE_Data.Repositories.Interfaces;
using ISHE_Data;
using ISHE_Utility.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using AutoMapper.QueryableExtensions;
using ISHE_Data.Entities;
using ISHE_Service.Interfaces;

namespace ISHE_Service.Implementations
{
    public class PolicyService : BaseService, IPolicyService
    {
        private readonly IPolicyRepository _policyRepository;
        private readonly IDevicePackageRepository _devicePackageRepository;

        public PolicyService(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
            _policyRepository = unitOfWork.Policy;
            _devicePackageRepository = unitOfWork.DevicePackage;
        }

        public async Task<PolicyViewModel> GetPolicy(Guid id)
        {
            return await _policyRepository.GetMany(policy => policy.Id.Equals(id))
                .ProjectTo<PolicyViewModel>(_mapper.ConfigurationProvider)
                .FirstOrDefaultAsync() ?? throw new NotFoundException("Không tìm thấy policy");
        }

        public async Task<PolicyViewModel> CreatePolicy(CreatePolicyModel model)
        {
            var devicePackage = await _devicePackageRepository.GetMany(device => device.Id.Equals(model.DevicePackageId))
                                .FirstOrDefaultAsync() ?? throw new NotFoundException("Không tìm thấy device package");

            var policy = new Policy
            {
                Id = Guid.NewGuid(),
                DevicePackageId = model.DevicePackageId,
                Type = model.Type,
                Content = model.Content,
            };

            _policyRepository.Add(policy);

            var result = await _unitOfWork.SaveChanges();

            return result > 0 ? await GetPolicy(policy.Id) : null!;
        }

        public async Task<PolicyViewModel> UpdatePolicy(Guid id, UpdatePolicyModel model)
        {
            var policy = await _policyRepository.GetMany(p => p.Id.Equals(id))
                .FirstOrDefaultAsync() ?? throw new NotFoundException("Không tìm thấy policy");

            policy.Type = model.Type ?? policy.Type;
            policy.Content = model.Content ?? policy.Content;

            _policyRepository.Update(policy);

            var result = await _unitOfWork.SaveChanges();

            return result > 0 ? await GetPolicy(policy.Id) : null!;
        }

    }
}
