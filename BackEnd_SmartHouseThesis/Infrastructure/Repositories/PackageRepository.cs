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
    public class PackageRepository : BaseRepo<Package>
    {
        private readonly AppDbContext _dbContext;
        private readonly ILogger<BaseRepo<Package>> _logger;
        public PackageRepository(AppDbContext dbContext, ILogger<BaseRepo<Package>> logger) : base(dbContext, logger)
        {
            _dbContext = dbContext;
            _logger = logger;
        }
        public PackageRepository(AppDbContext dbContext) : base(dbContext)
        {
        }
        public async Task<List<Package>> GetListPackagesByManufacturer(string manuName)
        {
            try
            {
                List<Package> packages = await _dbContext.Packages.Where(d => d.Manufacturer.Name == manuName).ToListAsync();
                return packages;
            }
            catch (Exception e)
            {
                _logger.LogError(e, "{Repo} GetListPackagesByManufacturer function error", typeof(BaseRepo<Package>));
                return null;
            }
        }
    }
}
