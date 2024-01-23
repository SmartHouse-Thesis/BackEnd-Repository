using Domain.Entities;
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
        public ContractRepository(AppDbContext dbContext, ILogger<BaseRepo<Contract>> logger) : base(dbContext, logger)
        {
        }
        public ContractRepository(AppDbContext dbContext) : base(dbContext)
        {

        }
    }
}
