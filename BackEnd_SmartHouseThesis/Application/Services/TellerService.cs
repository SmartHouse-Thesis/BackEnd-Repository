using Domain.Entities;
using Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class TellerService
    {
        private readonly TellerRepository _tellerRepository;
        private readonly AccountService _accountService;

        public TellerService(TellerRepository tellerRepository, AccountService accountService)
        {
            _tellerRepository = tellerRepository;
            _accountService = accountService;
        }

        public async Task CreateTeller(Teller teller) => await _tellerRepository.AddAsync(teller);

        public async Task UpdateTeller(Teller teller) => await _tellerRepository.UpdateAsync(teller);
        public async Task DeleteTeller(Teller teller) => await _tellerRepository.RemoveAsync(teller);

        public async Task<IQueryable<Teller>> GetAll() => await _tellerRepository.FindAllAsync();

        public async Task<Teller> GetTeller(Guid id) => await _tellerRepository.GetAsync(id);

        public async Task CreateTeller(Account account)
        {
            try
            {
                var _account = await _accountService.GetAccountByEmail(account.Email);
                if (_account == null)
                {
                    _account = await _accountService.CreateAccount(account);
                    var teller = new Teller();
                    teller.Id = _account.Id;
                    teller.Account = _account;
                    teller.RoleName = "Teller";
                    await CreateTeller(teller);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error At CreateTeller Service");
            }
        }
    }
}
