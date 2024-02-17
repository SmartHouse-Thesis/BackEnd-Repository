using Application.Services;
using AutoMapper;
using Domain.DTOs.Request;
using Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Principal;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BackEnd_SmartHouseThesis.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OwnerController : ControllerBase
    {
        private readonly OwnerService _OwnerService;
        private readonly AccountService _accountService;
        private readonly RoleService _roleService;
        private readonly IMapper _mapper;
        public OwnerController(OwnerService ownerService, AccountService accountService, RoleService roleService, IMapper mapper)
        {
            _OwnerService = ownerService;
            _mapper = mapper;
            _accountService = accountService;
            _roleService = roleService;
        }

        // GET: api/<OwnerController>/GetAllOwner
        [Authorize(Roles = "Owner")]
        [HttpGet("get-all-owner")]
        public async Task<IActionResult> GetAllOwner()
        {
            var owners = await _OwnerService.GetAll();
            return Ok(owners);
        }

        [Authorize(Roles = "Owner")]
        // GET api/<OwnerController>/GetOwner/5
        [HttpGet("get-owner/{id}")]
        public async Task<IActionResult> GetOwner(Guid id)
        {
            var owner = await _OwnerService.GetOwner(id);
            if (owner == null)
            {
                return NotFound();
            }
            return Ok(owner);
        }
    }
}
