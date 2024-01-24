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

        public StaffService(StaffRepository staffRepository)
        {
            _staffRepository = staffRepository;
        }

        public async Task CreateStaff(Staff staff) => await _staffRepository.AddAsync(staff);

        public async Task UpdateStaff(Staff staff) => await _staffRepository.UpdateAsync(staff);
        public async Task DeleteStaff(Staff staff) => await _staffRepository.RemoveAsync(staff);

        public async Task<IQueryable<Staff>> GetAll() => await _staffRepository.FindAllAsync();

        public async Task<Staff> GetStaff(Guid id) => await _staffRepository.GetAsync(id);


    }
}
