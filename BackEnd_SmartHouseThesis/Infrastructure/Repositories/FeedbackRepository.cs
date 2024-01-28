using Domain.Entities;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class FeedbackRepository : BaseRepo<Feedback>
    {
        private readonly AppDbContext _dbContext;
        private readonly ILogger<BaseRepo<Feedback>> _logger;
        public FeedbackRepository(AppDbContext dbContext, ILogger<BaseRepo<Feedback>> logger) : base(dbContext, logger)
        {
            _dbContext = dbContext;
            _logger = logger;
        }
        public FeedbackRepository(AppDbContext dbContext) : base(dbContext)
        {
        }
    }
}
