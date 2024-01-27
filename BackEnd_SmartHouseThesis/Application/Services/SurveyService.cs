using Domain.Entities;
using Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class SurveyService
    {
        private readonly SurveyRepository _surveyRepository;

        public SurveyService(SurveyRepository surveyRepository)
        {
            _surveyRepository = surveyRepository;
        }

        public async Task CreateSurvey(Survey survey) => await _surveyRepository.AddAsync(survey);

        public async Task UpdateSurvey(Survey survey) => await _surveyRepository.UpdateAsync(survey);
        public async Task DeleteSurvey(Survey survey) => await _surveyRepository.RemoveAsync(survey);

        public async Task<IQueryable<Survey>> GetAll() => await _surveyRepository.FindAllAsync();

        public async Task<Survey> GetSurvey(Guid id) => await _surveyRepository.GetAsync(id);
    }
}
