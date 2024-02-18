using Domain.Entities;
using Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class RequestService
    {
        private readonly RequestRepository _requestRepository;

        public RequestService(RequestRepository requestRepository)
        {
            _requestRepository = requestRepository;
        }

        public async Task CreateRequest(Request request) => await _requestRepository.AddAsync(request);

        public async Task UpdateRequest(Request request) => await _requestRepository.UpdateAsync(request);
        public async Task DeleteRequest(Request request) => await _requestRepository.RemoveAsync(request);

        public async Task<IQueryable<Request>> GetAll() => await _requestRepository.FindAllAsync();

        public async Task<Request> GetRequest(Guid id) => await _requestRepository.GetAsync(id);
        public async Task<List<Request>> GetRequestByStaffId(Guid staffId) => await _requestRepository.GetRequestByStaffId(staffId);
        public async Task<List<Request>> GetRequestByTellerId(Guid tellerId) => await _requestRepository.GetRequestByTellerId(tellerId);
    }
}
