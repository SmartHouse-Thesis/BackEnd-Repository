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
    public class TellerController : ControllerBase
    {
        private readonly TellerService _tellerServices;
        private readonly AccountService _accountService;
        private readonly RoleService _roleService;
        private readonly IMapper _mapper;
        public TellerController(TellerService tellerService, AccountService accountService, RoleService roleService, IMapper mapper)
        {
            _tellerServices = tellerService;
            _mapper = mapper;
            _accountService = accountService;
            _roleService = roleService;
        }
        [Authorize (Roles = "Owner")]
        // GET: api/<TellerController>/GetAllTeller
        [HttpGet("GetAllTeller")]
        public async Task<IActionResult> GetAllTeller()
        {
            var teller = await _tellerServices.GetAll();
            return Ok(teller);
        }
        [Authorize(Roles = "Owner")]
        // GET api/<TellerController>/GetTeller/5
        [HttpGet("GetTeller/{id}")]
        public async Task<IActionResult> GetTeller(Guid id)
        {
            var teller = await _tellerServices.GetTeller(id);
            if (teller == null)
            {
                return NotFound();
            }
            return Ok(teller);
        }
/*
        // POST api/<TellerController>/CreateTeller/{accountId}
        [HttpPost("CreateTeller/{accountId}")]
        public async Task<IActionResult> CreateTeller(Guid accountId)
        {
            var _account = await _accountService.GetAccount(accountId);
            if (_account != null)
            {
                var role = await _roleService.GetRole(_account.RoleId);
                if (role.Id == _account.RoleId)
                {
                    var teller = _mapper.Map<Teller>(_account);
                    await _tellerServices.CreateTeller(teller);
                    return Ok(teller);
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
