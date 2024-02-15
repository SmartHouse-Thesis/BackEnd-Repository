using Application.Services;
using AutoMapper;
using Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BackEnd_SmartHouseThesis.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StaffController : ControllerBase
    {
        private readonly StaffService _staffService;
        private readonly AccountService _accountService;
        private readonly RoleService _roleService;
        private readonly IMapper _mapper;
        public StaffController(StaffService staffService, AccountService accountService, RoleService roleService, IMapper mapper)
        {
            _staffService = staffService;
            _mapper = mapper;
            _accountService = accountService;
            _roleService = roleService;
        }
        [Authorize(Roles = "Owner")]
        // GET: api/<StaffController>/GetAllStaff
        [HttpGet("GetAllStaff")]
        public async Task<IActionResult> GetAllStaff()
        {
            var staff = await _staffService.GetAll();
            return Ok(staff);
        }

        [Authorize(Roles = "Owner, Teller")]
        [HttpGet("GetAllStaffFree/{startdate}/{enddate}")]
        public async Task<IActionResult> GetAllStaffFree(DateTime startdate, DateTime enddate)
        {
            var staffFree = await _staffService.GetListStaffFree(startdate, enddate);
            return Ok(staffFree);
        }

        [Authorize(Roles = "Owner, Teller")]
        [HttpGet("GetStaffForSurvey/{requestDate}")]
        public async Task<IActionResult> GetStaffForSurvey(DateTime requestDate)
        {
            var staffFree = await _staffService.GetListStaffFreeSurvey(requestDate);
            return Ok(staffFree);
        }

        [Authorize(Roles = "Owner, Teller")]
        // GET api/<StaffController>/GetStaff/5
        [HttpGet("GetStaff/{id}")]
        public async Task<IActionResult> GetStaff(Guid id)
        {
            var staff = await _staffService.GetStaff(id);
            if (staff == null)
            {
                return NotFound();
            }
            return Ok(staff);
        }

/*        [Authorize(Roles = "Owner")]
        // POST api/<StaffController>/CreateStaff/{accountId}
        [HttpPost("CreateStaff/{accountId}")]
        public async Task<IActionResult> CreateStaff(Guid accountId)
        {
            var _account = await _accountService.GetAccount(accountId);
            if (_account != null)
            {
                var role = await _roleService.GetRole(_account.RoleId);
                if (role.Id == _account.RoleId)
                {
                    var staff = _mapper.Map<Staff>(_account);
                    await _staffService.CreateStaff(staff);
                    return Ok(staff);
                }
                else
                {
                    return BadRequest("Can't do this right now");
                }
            }
            else
            {
                return BadRequest("Account doesn't exist!!");
            }
        }*/
    }
}
