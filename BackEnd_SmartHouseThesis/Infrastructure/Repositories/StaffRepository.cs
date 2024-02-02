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
    public class StaffRepository : BaseRepo<Staff>
    {
        private readonly AppDbContext _dbContext;
        private readonly ILogger<BaseRepo<Staff>> _logger;
        private readonly ContractRepository _contractRepository;
        public StaffRepository(AppDbContext dbContext, ILogger<BaseRepo<Staff>> logger, ContractRepository contractRepository) : base(dbContext, logger)
        {
            _dbContext = dbContext;
            _logger = logger;
            _contractRepository = contractRepository;
        }
        public StaffRepository(AppDbContext dbContext) : base(dbContext)
        {

        }
        public async Task<List<Staff>> GetListStaffFree(DateTime NewStartPlan, DateTime NewEndPlan)
        {
            List<Staff> listStaffFree = new List<Staff>();
            var listStaff = await _dbContext.Staff.Where(s => s.isLeader == true).ToListAsync();
            foreach (var staff in listStaff)
            {
                List<Contract> contracts = await _contractRepository.GetContractsByStaff(staff.Id);
                int contractCount = contracts.Count();
                int contractFreeCount = 0;
                foreach (var contract in contracts)
                {
                    if ((NewStartPlan < contract.StartPlanDate && NewEndPlan < contract.EndPlanDate) || (NewStartPlan > contract.StartPlanDate && NewEndPlan > contract.EndPlanDate))
                    {
                        contractFreeCount += 1;
                    }
                }
                if(contractFreeCount == contractCount)
                {
                    listStaffFree.Add(staff);
                }
            }
            return listStaffFree;
        }

        public async Task<List<Staff>> GetListStaffFreeSurvey(DateTime requestDate)
        {
            List<Staff> listStaffFree = new List<Staff>();
            var listStaff = await _dbContext.Staff.Where(s => s.isLeader == true).ToListAsync();
            foreach (var staff in listStaff)
            {
                List<Contract> contracts = await _contractRepository.GetContractsByStaff(staff.Id);
                int contractCount = contracts.Count();
                int requestFreeCount = 0;
                foreach (var contract in contracts)
                {
                    if ((requestDate < contract.StartPlanDate && requestDate < contract.EndPlanDate) || (requestDate > contract.StartPlanDate && requestDate > contract.EndPlanDate))
                    {
                        requestFreeCount += 1;
                    }
                }
                if (requestFreeCount == contractCount)
                {
                    listStaffFree.Add(staff);
                }
            }
            return listStaffFree;
        }
    }
}

