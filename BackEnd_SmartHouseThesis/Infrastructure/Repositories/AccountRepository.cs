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
    public class AccountRepository : BaseRepo<Account>
    {
        public AccountRepository(AppDbContext dbContext, ILogger<BaseRepo<Account>> logger) : base(dbContext, logger)
        {
            _dbContext = dbContext;
            _logger = logger;
        }
        public AccountRepository(AppDbContext dbContext) : base(dbContext)
        {

        }
        private readonly AppDbContext _dbContext;
        private readonly ILogger<BaseRepo<Account>> _logger;
        public async Task<Account> GetAccountByEmail(string email)
        {
            try
            {
                Account item = await _dbContext.Set<Account>().FirstOrDefaultAsync(a =>a.Email == email);
                return item;
            }
            catch (Exception e)
            {
                _logger.LogError(e, "{Repo} GetAccountByEmailAsync function error", typeof(BaseRepo<Account>));
                return null;
            }
        }
    }
}
