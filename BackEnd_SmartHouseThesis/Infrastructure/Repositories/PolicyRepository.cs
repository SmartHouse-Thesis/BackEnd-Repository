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
    public class PolicyRepository : BaseRepo<Policy>
    {
        private readonly AppDbContext _dbContext;
        private readonly ILogger<BaseRepo<Policy>> _logger;
        public PolicyRepository(AppDbContext dbContext, ILogger<BaseRepo<Policy>> logger) : base(dbContext, logger)
        {
            _dbContext = dbContext;
            _logger = logger;
        }
        public PolicyRepository(AppDbContext dbContext) : base(dbContext)
        {
        }
        public async Task<List<Policy>> SearchPolicyByType(string type)
        {
            try
            {
                List<Policy> policies = await _dbContext.Policy.Where(x => x.Type.Equals(type)).ToListAsync();
                return policies;
            }
            catch (Exception e)
            {
                _logger.LogError(e, "{Repo} SearchPolicyByType function error", typeof(BaseRepo<Policy>));
                return null;
            }
        }
    }
}
