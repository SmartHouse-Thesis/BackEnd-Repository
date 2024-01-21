using Domain.Entities;
using Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class PromotionService
    {
        private readonly PromotionRepository _pomotionRepository;

        public PromotionService(PromotionRepository promotionRepository)
        {
            _pomotionRepository = promotionRepository;
        }

        public async Task CreatePromotion(Promotion promo) => await _pomotionRepository.AddAsync(promo);

        public async Task UpdatePromotion(Promotion promo) => await _pomotionRepository.UpdateAsync(promo);
        public async Task DeletePromotion(Promotion promo) => await _pomotionRepository.RemoveAsync(promo);

        public async Task<IQueryable<Promotion>> GetAll() => await _pomotionRepository.FindAllAsync();

        public async Task<Promotion> GetPromotion(Guid id) => await _pomotionRepository.GetAsync(id);
    }
}
