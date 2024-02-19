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
    public class ContractRepository : BaseRepo<Contract>
    {
        private readonly AppDbContext _dbContext;
        private readonly ILogger<BaseRepo<Contract>> _logger;
        public ContractRepository(AppDbContext dbContext, ILogger<BaseRepo<Contract>> logger) : base(dbContext, logger)
        {
            _dbContext = dbContext;
            _logger = logger;
        }
        public ContractRepository(AppDbContext dbContext) : base(dbContext)
        {

        }
        public async Task<List<Contract>> GetContractsByStaff(Guid staffId)
        {
            try
            {
                List<Contract> contracts = await _dbContext.Contracts.Where(c => c.Staff.Id == staffId).ToListAsync();
                return contracts;
            }
            catch (Exception e)
            {
                _logger.LogError(e, "{Repo} GetContractsByStaff function error", typeof(BaseRepo<Contract>));
                return null;
            }
        }
        public async Task<List<Contract>> SearchContractByCustomerName(string name)
        {
            try
            {
                var customers = await _dbContext.Customers.Where(c => c.Account.FirstName.Contains(name) || c.Account.LastName.Contains(name)).ToListAsync();
                var _contracts = new List<Contract>();
                foreach (var customer in customers)
                {
                    var contracts = await _dbContext.Contracts.Where(c => c.CustomerId == customer.Id).ToListAsync();
                    _contracts.AddRange(contracts);
                }
                if (_contracts != null)
                {
                    return _contracts;
                }
                return null;
            }
            catch (Exception e)
            {
                _logger.LogError(e, "{Repo} SearchContractByCustomerName function error", typeof(BaseRepo<Contract>));
                return null;
            }
        }
    }
}
