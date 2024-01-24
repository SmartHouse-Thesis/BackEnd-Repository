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

        public TellerService(TellerRepository tellerRepository)
        {
            _tellerRepository = tellerRepository;
        }

        public async Task CreateTeller(Teller teller) => await _tellerRepository.AddAsync(teller);

        public async Task UpdateTeller(Teller teller) => await _tellerRepository.UpdateAsync(teller);
        public async Task DeleteTeller(Teller teller) => await _tellerRepository.RemoveAsync(teller);

        public async Task<IQueryable<Teller>> GetAll() => await _tellerRepository.FindAllAsync();

        public async Task<Teller> GetTeller(Guid id) => await _tellerRepository.GetAsync(id);
    }
}
