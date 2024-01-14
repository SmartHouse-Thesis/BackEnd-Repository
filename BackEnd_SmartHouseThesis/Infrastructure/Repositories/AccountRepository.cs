using Domain.Entities;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class AccountRepository : BaseRepo<Account>
    {
        public AccountRepository(AppDbContext dbContext) : base(dbContext)
        {
        }
    }
}
