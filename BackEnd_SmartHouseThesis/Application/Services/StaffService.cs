using Domain.Entities;
using Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class StaffService
    {
        private readonly StaffRepository _staffRepository;
        private readonly ContractRepository _contractRepository;

        public StaffService(StaffRepository staffRepository, ContractRepository contractRepository)
        {
            _staffRepository = staffRepository;
            _contractRepository = contractRepository;
        }

        public async Task CreateStaff(Staff staff) => await _staffRepository.AddAsync(staff);

        public async Task UpdateStaff(Staff staff) => await _staffRepository.UpdateAsync(staff);
        public async Task DeleteStaff(Staff staff) => await _staffRepository.RemoveAsync(staff);

        public async Task<IQueryable<Staff>> GetAll() => await _staffRepository.FindAllAsync();

        public async Task<Staff> GetStaff(Guid id) => await _staffRepository.GetAsync(id);

        public async Task<List<Staff>> GetListStaffFree(DateTime NewStartPlan, DateTime NewEndPlan) => await _staffRepository.GetListStaffFree(NewStartPlan, NewEndPlan);

        public async Task<List<Staff>> GetListStaffFreeSurvey(DateTime requestDate) => await _staffRepository.GetListStaffFreeSurvey(requestDate);
    }
}
