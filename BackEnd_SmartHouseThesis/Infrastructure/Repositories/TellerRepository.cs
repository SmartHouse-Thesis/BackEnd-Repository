using Domain.Entities;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class TellerRepository : BaseRepo<Teller>
    {
        public TellerRepository(AppDbContext dbContext, ILogger<BaseRepo<Teller>> logger) : base(dbContext, logger)
        {
        }
        public TellerRepository(AppDbContext dbContext) : base(dbContext)
        {

        }
    }
}
