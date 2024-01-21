using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class PolicyRepository : BaseRepo<Policy>
    {
        public PolicyRepository(AppDbContext dbContext) : base(dbContext)
        {
        }
    }
}
