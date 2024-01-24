using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class OwnerRepository : BaseRepo<Owner>
    {
        private readonly AppDbContext _dbContext;
        private readonly ILogger<BaseRepo<Owner>> _logger;
        public OwnerRepository(AppDbContext dbContext, ILogger<BaseRepo<Owner>> logger) : base(dbContext, logger)
        {
            _dbContext = dbContext;
            _logger = logger;
        }
        public OwnerRepository(AppDbContext dbContext) : base(dbContext)
        {
        }         
    }
}
