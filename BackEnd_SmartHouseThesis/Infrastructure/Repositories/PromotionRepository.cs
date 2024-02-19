using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class PromotionRepository : BaseRepo<Promotion>
    {
        private readonly AppDbContext _dbContext;
        private readonly ILogger<BaseRepo<Promotion>> _logger;
        public PromotionRepository(AppDbContext dbContext, ILogger<BaseRepo<Promotion>> logger) : base(dbContext, logger)
        {
            _dbContext = dbContext;
            _logger = logger;
        }
        public PromotionRepository(AppDbContext dbContext) : base(dbContext)
        {
        }
        public async Task<List<Promotion>> SearchPromotionByName(string name)
        {
            try
            {
                List<Promotion> promotions = await _dbContext.Promotion.Where(x => x.Name.Equals(name)).ToListAsync();
                return promotions;
            }
            catch (Exception e)
            {
                _logger.LogError(e, "{Repo} SearchPromotionByName function error", typeof(BaseRepo<Promotion>));
                return null;
            }
        }
    }
}
