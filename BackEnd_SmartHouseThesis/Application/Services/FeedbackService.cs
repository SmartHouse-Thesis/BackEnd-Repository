using Domain.Entities;
using Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class FeedbackService
    {
        private readonly FeedbackRepository _feedbackRepository;

        public FeedbackService(FeedbackRepository feedbackRepository)
        {
            _feedbackRepository = feedbackRepository;
        }

        public async Task CreateFeedback(Feedback feedback) => await _feedbackRepository.AddAsync(feedback);

        public async Task UpdateFeedback(Feedback feedback) => await _feedbackRepository.UpdateAsync(feedback);
        public async Task DeleteFeedback(Feedback feedback) => await _feedbackRepository.RemoveAsync(feedback);

        public async Task<IQueryable<Feedback>> GetAll() => await _feedbackRepository.FindAllAsync();

        public async Task<Feedback> GetFeedback(Guid id) => await _feedbackRepository.GetAsync(id);
    }
}
