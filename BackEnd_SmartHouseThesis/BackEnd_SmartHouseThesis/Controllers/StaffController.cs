using Application.Services;
using AutoMapper;
using Domain.DTOs.Request.Get;
using Domain.DTOs.Response;
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
        [Authorize(Roles = "Owner, Teller, Staff")]
        // GET: api/<StaffController>/GetAllStaff
        [HttpGet("get-all-staff")]
        public async Task<IActionResult> GetAllStaff()
        {
            try
            {
                    var staffs = await _staffService.GetAll();
                    var liststaff = new List<StaffResponse>();
                    foreach (var item in staffs)
                    {
                        var staffMap = _mapper.Map<StaffResponse>(item);
                        liststaff.Add(staffMap);
                    }
                    return Ok(liststaff);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new AuthenResponse { Message = "get-all-staff controller !! " });
            }
        }

        [Authorize(Roles = "Owner, Teller")]
        [HttpGet("get-all-staff-free/")]
        public async Task<IActionResult> GetAllStaffFree([FromBody]GetAllStaffFree staff)
        {
            try
            {
                var staffFree = await _staffService.GetListStaffFree(staff.StartDate, staff.EndDate);
                if(staffFree != null)
                {
                    var liststaff = new List<StaffResponse>();
                    foreach (var item in staffFree)
                    {                       
                            var staffMap = _mapper.Map<StaffResponse>(item);
                            liststaff.Add(staffMap);                 
                    }
                    return Ok(staffFree);
                }
                return Ok("Không có nhân viên rảnh !!");
            }
            catch (Exception ex)
            {
                return StatusCode(500, new AuthenResponse { Message = "lỗi get-all-staff-free controller !! " });
            }
            
        }

        [Authorize(Roles = "Owner, Teller")]
        [HttpGet("get-staff-for-survey/{requestDate}")]
        public async Task<IActionResult> GetStaffForSurvey(DateTime requestDate)
        {
            try
            {
                var staffFree = await _staffService.GetListStaffFreeSurvey(requestDate);
                if (staffFree != null)
                {
                    var liststaff = new List<StaffResponse>();
                    foreach (var item in staffFree)
                    {
                        var staffMap = _mapper.Map<StaffResponse>(item);
                        liststaff.Add(staffMap);
                    }
                    return Ok(staffFree);
                }
                return Ok("Không có nhân viên rảnh");
            }
            catch (Exception ex)
            {
                return StatusCode(500, new AuthenResponse { Message = "lỗi get-staff-for-survey controller !! " });
            }
            
            
        }

        [Authorize(Roles = "Owner, Teller")]
        // GET api/<StaffController>/GetStaff/5
        [HttpGet("get-staff/{id}")]
        public async Task<IActionResult> GetStaff(Guid id)
        {
            var staff = await _staffService.GetStaff(id);
            if (staff != null)
            {
                var accountStaff = _accountService.GetAccount(staff.Id);
                if (accountStaff != null)
                {
                    var staffAccount = _mapper.Map<StaffResponse>(accountStaff);
                    return Ok(staffAccount);
                }
                return NotFound("Không tìm thấy tài khoản nhân viên");
            }
            return NotFound("Nhân Viên không tồn tại ");
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
