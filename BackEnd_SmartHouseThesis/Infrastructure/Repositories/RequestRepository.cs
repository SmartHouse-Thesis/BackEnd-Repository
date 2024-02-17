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
    public class RequestRepository : BaseRepo<Request>
    {
        private readonly AppDbContext _dbContext;
        private readonly ILogger<BaseRepo<Request>> _logger;
        private readonly SurveyRepository _surveyRepository;
        public RequestRepository(AppDbContext dbContext) : base(dbContext)
        {
        }

        public RequestRepository(AppDbContext dbContext, ILogger<BaseRepo<Request>> logger, SurveyRepository surveyRepository) : base(dbContext, logger)
        {
            _dbContext = dbContext;
            _logger = logger;
            _surveyRepository = surveyRepository;
        }
        public async Task<List<Request>> GetRequestByStaffId(Guid staffId)
        {
            try
            {
                List<Request> requests = new List<Request>();
                List<Survey> surveys = await _surveyRepository.GetSurveysByStaff(staffId);
                foreach(Survey survey in surveys)
                {
                    var request = await _dbContext.Requests.Where(r => r.Survey.Id == survey.Id).FirstOrDefaultAsync();
                    if(request != null) { requests.Add(request); }
                }
                return requests;
            }
            catch (Exception e)
            {
                _logger.LogError(e, "{Repo} GetRequestByStaffId function error", typeof(BaseRepo<Contract>));
                return null;
            }
        }

        public async Task<List<Request>> GetRequestByTellerId(Guid tellerId)
        {
            try
            {
                List<Request> requests = new List<Request>();
                List<Survey> surveys = await _surveyRepository.GetSurveysByTeller(tellerId);
                foreach (var survey in surveys)
                {
                    var request = await _dbContext.Requests.Where(r => r.Survey.RequestId == survey.RequestId).FirstOrDefaultAsync();
                    if (request != null) { requests.Add(request); }
                }
                return requests;
            }
            catch (Exception e)
            {
                _logger.LogError(e, "{Repo} GetRequestByStaffId function error", typeof(BaseRepo<Contract>));
                return null;
            }
        }

    }
}
