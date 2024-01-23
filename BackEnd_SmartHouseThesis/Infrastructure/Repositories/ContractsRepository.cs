using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class ContractsRepository : BaseRepo<ConstractRepository>
    {
        public ContractsRepository(AppDbContext dbContext) : base(dbContext)
        {
        }
    }
}
