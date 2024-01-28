using Domain.Entities;
using Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public  class AccpetanceService
    {
        private readonly AcceptanceRepossitory _acceptanceRepository;

        public AccpetanceService(AcceptanceRepossitory acceptanceRepository)
        {
            _acceptanceRepository = acceptanceRepository;
        }
        public async Task CreateAcceptance(Acceptance acceptance) => await _acceptanceRepository.AddAsync(acceptance);

        public async Task UpdateAcceptance(Acceptance acceptance) => await _acceptanceRepository.UpdateAsync(acceptance);

        public async Task DeleteAcceptance(Acceptance acceptance) => await _acceptanceRepository.RemoveAsync(acceptance);

        public async Task<IQueryable<Acceptance>> GetAll() => await _acceptanceRepository.FindAllAsync();

        public async Task<Acceptance> GetAcceptance(Guid id) => await _acceptanceRepository.GetAsync(id);
    }
}
