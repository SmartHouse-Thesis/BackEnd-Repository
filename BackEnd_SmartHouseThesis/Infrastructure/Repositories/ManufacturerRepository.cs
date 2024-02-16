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
    public class ManufactureRepository : BaseRepo<Manufacturer>
    {
        private readonly AppDbContext _dbContext;
        private readonly ILogger<BaseRepo<Manufacturer>> _logger;
        public ManufactureRepository(AppDbContext dbContext, ILogger<BaseRepo<Manufacturer>> logger) : base(dbContext, logger)
        {
            _dbContext = dbContext;
            _logger = logger;
        }
        public ManufactureRepository(AppDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<Manufacturer> GetManufacturerByName(string name)
        {
            try
            {
                Manufacturer item = await _dbContext.Set<Manufacturer>().FirstOrDefaultAsync(a => a.Name == name);
                if (item != null)
                {
                    return item;
                }
                return null;
            }
            catch (Exception e)
            {
                _logger.LogError(e, "{Repo} GetManufacturerByName function error", typeof(BaseRepo<Manufacturer>));
                return null;
            }
        }

    }
}
