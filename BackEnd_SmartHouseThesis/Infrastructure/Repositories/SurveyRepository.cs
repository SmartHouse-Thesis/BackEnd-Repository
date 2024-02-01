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
    public class SurveyRepository : BaseRepo<Survey>
    {
        private readonly AppDbContext _dbContext;
        private readonly ILogger<BaseRepo<Survey>> _logger;
        public SurveyRepository(AppDbContext dbContext, ILogger<BaseRepo<Survey>> logger) : base(dbContext, logger)
        {
            _dbContext = dbContext;
            _logger = logger;
        }
        public SurveyRepository(AppDbContext dbContext) : base(dbContext)
        {

        }
        public async Task<List<Survey>> GetSurveysByStaff(Guid staffId)
        {
            try
            {
                List<Survey> surveys = await _dbContext.Surveys.Where(s => s.Staff.Id == staffId).ToListAsync();
                return surveys;
            }
            catch (Exception e)
            {
                _logger.LogError(e, "{Repo} GetSurveysByStaff function error", typeof(BaseRepo<Survey>));
                return null;
            }
        }
    }
}
