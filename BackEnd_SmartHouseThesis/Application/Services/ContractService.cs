using Domain.Entities;
using Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class ContractService
    {
        private readonly ContractRepository _contractRepository;

        public ContractService(ContractRepository contractRepository)
        {
            _contractRepository = contractRepository;
        }

        public async Task CreateContract(Contract contract) => await _contractRepository.AddAsync(contract);

        public async Task UpdateContract(Contract contract) => await _contractRepository.UpdateAsync(contract);
        public async Task DeleteContract(Contract contract) => await _contractRepository.RemoveAsync(contract);

        public async Task<IQueryable<Contract>> GetAll() => await _contractRepository.FindAllAsync();

        public async Task<Contract> GetContract(Guid id) => await _contractRepository.GetAsync(id);

        public async Task<List<Contract>> SearchContractByCustomerName(string name) => await _contractRepository.SearchContractByCustomerName(name);
    }
}
