using Domain.Entities;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class StaffRepository : BaseRepo<Staff>
    {
        public StaffRepository(AppDbContext dbContext, ILogger<BaseRepo<Staff>> logger) : base(dbContext, logger)
        {
        }
        public StaffRepository(AppDbContext dbContext) : base(dbContext)
        {

        }
    }
}

