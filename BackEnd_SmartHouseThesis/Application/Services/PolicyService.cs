using Domain.Entities;
using Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class PolicyService 
    {
        private readonly PolicyRepository _policyRepository;

        public PolicyService(PolicyRepository policyRepository)
        {
            _policyRepository = policyRepository;
        }

        public async Task CreatePolicy(Policy policy) => await _policyRepository.AddAsync(policy);

        public async Task UpdatePolicy(Policy policy) => await _policyRepository.UpdateAsync(policy);
        public async Task DeletePolicy(Policy policy) => await _policyRepository.RemoveAsync(policy);

        public async Task<IQueryable<Policy>> GetAll() => await _policyRepository.FindAllAsync();

        public async Task<Policy> GetPolicy(Guid id) => await _policyRepository.GetAsync(id);
    }
}
