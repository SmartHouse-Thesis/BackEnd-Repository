using Application.Services;
using AutoMapper;
using Domain.DTOs.Request;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Security.Principal;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BackEnd_SmartHouseThesis.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OwnerController : ControllerBase
    {
/*        private readonly OwnerService _OwnerService;
        private readonly AccountService _accountService;
        private readonly RoleService _roleService;
        private readonly IMapper _mapper;
        public OwnerController(OwnerService ownerService, AccountService accountService,RoleService roleService,IMapper mapper)
        {
            _OwnerService = ownerService;
            _mapper = mapper;
            _accountService = accountService;
            _roleService = roleService;
        }

        // GET: api/<OwnerController>/GetAllOwner
        [HttpGet("GetAllOwner")]
        public async Task<IActionResult> GetAllOwner()
        {
            var owners = await _OwnerService.GetAll();
            return Ok(owners);
        }

        // GET api/<OwnerController>/GetOwner/5
        [HttpGet("GetOwner/{id}")]
        public async Task<IActionResult> GetOwner(Guid id)
        {
            var owner = await _OwnerService.GetOwner(id);
            if (owner == null)
            {
                return NotFound();
            }
            return Ok(owner);
        }



        // POST api/<OwnerController>/CreateOwner/{accountId}
        [HttpPost("CreateOwner/{accountId}")]
        public async Task<IActionResult> CreateOwner(Guid accountId)
        {
            var _account = await _accountService.GetAccount(accountId);
            if (_account != null)
            {
                var role = await _roleService.GetRole(_account.RoleId);
                if (role.Id == _account.RoleId)
                {
                    var owner = _mapper.Map<Owner>(_account);
                    await _OwnerService.CreateOwner(owner);
                    return Ok(owner);
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
