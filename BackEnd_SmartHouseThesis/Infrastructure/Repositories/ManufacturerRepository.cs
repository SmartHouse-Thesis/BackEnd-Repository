using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class ManufactureRepository : BaseRepo<Manufacture>
    {
        public ManufactureRepository(AppDbContext dbContext) : base(dbContext)
        {
        }
    }
}
