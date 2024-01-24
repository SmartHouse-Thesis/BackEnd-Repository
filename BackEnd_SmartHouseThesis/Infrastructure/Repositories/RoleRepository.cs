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
    public class RoleRepository : BaseRepo<Role>
    {
        private readonly AppDbContext _dbContext;
        private readonly ILogger<BaseRepo<Role>> _logger;
        public RoleRepository(AppDbContext dbContext, ILogger<BaseRepo<Role>> logger) : base(dbContext, logger)
        {
            _dbContext = dbContext;
            _logger = logger;
        }
        public RoleRepository(AppDbContext dbContext) : base(dbContext)
        {

        }

        public async Task<Role> GetRoleByRoleName(string roleName)
        {
            try
            {
                Role item = await _dbContext.Set<Role>().FirstOrDefaultAsync(r => r.RoleName == roleName);
                return item;
            }
            catch (Exception e)
            {
                _logger.LogError(e, "{Repo} GetRoleByRoleName function error", typeof(BaseRepo<Role>));
                return null;
            }
        }
    }
}
