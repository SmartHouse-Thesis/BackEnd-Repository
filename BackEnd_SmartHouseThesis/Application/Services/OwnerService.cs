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
    public class OwnerService 
    {
        private readonly OwnerRepository _ownerRepository;
        private readonly AccountService _accountService;
        public OwnerService(OwnerRepository ownerRepository, AccountService accountService)
        {
            _ownerRepository = ownerRepository;
            _accountService = accountService;
        }

        public async Task UpdateOwner(Owner owner) => await _ownerRepository.UpdateAsync(owner);
        public async Task DeleteOwner(Owner owner) => await _ownerRepository.RemoveAsync(owner);
        public async Task<IQueryable<Owner>> GetAll() => await _ownerRepository.FindAllAsync();
        public async Task<Owner> GetOwner(Guid id) => await _ownerRepository.GetAsync(id);
        public async Task CreateOwner(Owner owner) => await _ownerRepository.AddAsync(owner);

        public async Task CreateOwner(Account account)
        {
            try
            {
                var _account = await _accountService.GetAccountByEmail(account.Email);
                if (_account == null)
                {
                    _account = await _accountService.CreateAccount(account);
                    var owner = new Owner();
                    owner.Id = _account.Id;
                    owner.Account = _account;
                    owner.RoleName = "Teller";
                    await CreateOwner(owner);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error At CreateTeller Service");
            }
        }
    }
}
