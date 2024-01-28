using Domain.Entities;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class AcceptanceRepossitory : BaseRepo<Acceptance>
    {
        public AcceptanceRepossitory(AppDbContext dbContext) : base(dbContext)
        {
        }

        public AcceptanceRepossitory(AppDbContext dbContext, ILogger<BaseRepo<Acceptance>> logger) : base(dbContext, logger)
        {
        }
    }
}
