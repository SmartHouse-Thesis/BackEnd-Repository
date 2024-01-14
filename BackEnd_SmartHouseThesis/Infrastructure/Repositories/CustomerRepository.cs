using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class CustomerRepository : BaseRepo<Customer>
    {
        public CustomerRepository(AppDbContext dbContext) : base(dbContext)
        {
        }
    }
}
