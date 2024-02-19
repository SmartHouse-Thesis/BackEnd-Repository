using Application.UseCase.Sercurity;
using Domain.DTOs.Request.Post;
using Domain.DTOs.Response;
using Domain.Entities;
using Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class AccountService
    {
        private readonly AccountRepository _accountRepository;
        private readonly PasswordHash _passwordHash;
        private readonly RoleService _roleService;
        public AccountService(AccountRepository accountRepository, PasswordHash passwordHash, RoleService roleService)
        {
            _accountRepository = accountRepository;
            _roleService = roleService;
            _passwordHash = passwordHash;
        }
        public async Task CreateAccountAsync(Account account) => await _accountRepository.AddAsync(account);

        public async Task<Account> CreateAccount(Account account) => await _accountRepository.CreateAccount(account);

        public async Task UpdateAccount(Account account) {
            var _acc = GetAccount(account.Id);
                if(_acc != null)
            {
                await _accountRepository.UpdateAsync(account);
            }
                       
        }
        public async Task<Account> Authenticate(string email, string password)
        {
           var acc = GetAccountByEmail(email);
            if(acc != null)
            {
                if(_passwordHash.VerifyPassword(password, acc.Result.Password))
                {
                    return await acc;
                }
            }
            return null;
        }

        public async Task DeleteAccount(Account account) => await _accountRepository.RemoveAsync(account);

        public async Task<IQueryable<Account>> GetAll() => await _accountRepository.FindAllAsync();

        public async Task<Account> GetAccount(Guid id) => await _accountRepository.GetAsync(id);

        public async Task<Account> GetAccountByEmail(string email) => await _accountRepository.GetAccountByEmail(email);

        public async Task<IQueryable<Account>> GetAccountStaffandTeller() => await _accountRepository.GetAccountStaffandTeller();
    }
}
