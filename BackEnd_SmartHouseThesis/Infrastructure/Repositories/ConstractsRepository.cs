using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class ConstractsRepository : BaseRepo<ConstractsRepository>
    {
        public ConstractsRepository(AppDbContext dbContext) : base(dbContext)
        {
        }
    }
}
