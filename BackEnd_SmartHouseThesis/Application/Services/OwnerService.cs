using Application.UseCase;
using Domain.Entities;
using Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class OwnerService : IOwnerService
    {
        private readonly OwnerRepository _ownerRepository;

        public OwnerService(OwnerRepository ownerRepository)
        {
            _ownerRepository = ownerRepository;
        }

        public async Task CreateOwner(Owner owner) => await _ownerRepository.AddAsync(owner);

        public async Task UpdateOwner(Owner owner) => await _ownerRepository.UpdateAsync(owner);
        public async Task DeleteOwner(Owner owner) => await _ownerRepository.RemoveAsync(owner);

        public async Task<IQueryable<Owner>> GetAll() => await _ownerRepository.FindAllAsync();

        public async Task<Owner> GetOwner(Guid id) => await _ownerRepository.GetAsync(id);

    }
}
