using Domain.Entities;
using Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class OwnerService
    {
        private readonly OwnerRepository _ownerRepository;

        public OwnerService(OwnerRepository ownerRepository)
        {
            _ownerRepository = ownerRepository;
        }

        public async Task CreateAccount(Owner owner) => await _ownerRepository.AddAsync(owner);

        public async Task UpdateAccount(Owner owner) => await _ownerRepository.UpdateAsync(owner);
        public async Task DeleteAccount(Owner owner) => await _ownerRepository.RemoveAsync(owner);

        public async Task<IQueryable<Owner>> GetAll() => await _ownerRepository.FindAllAsync();

        public async Task<Owner> GetAccount(Guid id) => await _ownerRepository.GetAsync(id);
    }
}
