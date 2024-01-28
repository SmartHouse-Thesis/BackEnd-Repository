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

        public AccountService(AccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }
        public async Task CreateAccount(Account account) => await _accountRepository.AddAsync(account);

        public async Task UpdateAccount(Account account) => await _accountRepository.UpdateAsync(account);

        public async Task DeleteAccount(Account account) => await _accountRepository.RemoveAsync(account);

        public async Task<IQueryable<Account>> GetAll() => await _accountRepository.FindAllAsync();

        public async Task<Account> GetAccount(Guid id) => await _accountRepository.GetAsync(id);

        public async Task<Account> GetAccountByEmail(string email) => await _accountRepository.GetAccountByEmail(email);
    }
}
