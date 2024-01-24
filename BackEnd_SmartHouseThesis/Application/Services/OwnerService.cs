using Application.UseCase;
using AutoMapper;
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
        private readonly AccountRepository _accountRepository;
        private readonly IMapper _mapper;
        public OwnerService(OwnerRepository ownerRepository,AccountRepository accountRepository, IMapper mapper)
        {
            _ownerRepository = ownerRepository;
            _accountRepository = accountRepository;
            _mapper = mapper;
        }

        public async Task UpdateOwner(Owner owner) => await _ownerRepository.UpdateAsync(owner);
        public async Task DeleteOwner(Owner owner) => await _ownerRepository.RemoveAsync(owner);
        public async Task<IQueryable<Owner>> GetAll() => await _ownerRepository.FindAllAsync();
        public async Task<Owner> GetOwner(Guid id) => await _ownerRepository.GetAsync(id);
        public async Task CreateOwner(Owner owner) => await _ownerRepository.AddAsync(owner);

        /* public async Task<Owner> GetEmailAccount(string email)
         {
             var account = await _accountRepository.GetAccountByEmail(email);
             if(account != null)
             {
                 if(account.Role.RoleName == "Owner")
                 {
                     var owner = _mapper.Map<Owner>(account);
                     CreateOwner(owner);
                 }
             }else
             {
                 return null;
             }

         }*/

    }
}
