using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class OwnerRepository : BaseRepo<Owner>
    {
        public OwnerRepository(AppDbContext dbContext) : base(dbContext)
        {

        }
    }
}
