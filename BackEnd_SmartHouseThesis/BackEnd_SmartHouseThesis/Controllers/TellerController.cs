using Application.Services;
using AutoMapper;
using Domain.DTOs.Response;
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
        [Authorize (Roles = "Owner, Teller, Customer, Staff")]
        // GET: api/<TellerController>/GetAllTeller
        [HttpGet("get-all-teller")]
        public async Task<IActionResult> GetAllTeller()
        {
            var teller = await _tellerServices.GetAll();
            return Ok(teller);
            /*var tellers = await _tellerServices.GetAll();
            var listTeller = new List<StaffResponse>();
            foreach (var item in tellers)
            {
                var accountTeller = _accountService.GetAccount(item.Id);
                if (accountTeller != null)
                {
                    var _accountTeller = _mapper.Map<StaffResponse>(accountTeller);
                    listTeller.Add(_accountTeller);
                }
                *//*var tellerMap = _mapper.Map<StaffResponse>(item);
                listTeller.Add(tellerMap);*//*
            }
            return Ok(listTeller);*/
        }

        [Authorize(Roles = "Owner, Teller, Customer, Staff")]
        // GET api/<TellerController>/GetTeller/5
        [HttpGet("get-teller/{id}")]
        public async Task<IActionResult> GetTeller(Guid id)
        {
            var teller = await _tellerServices.GetTeller(id);
            if (teller == null)
            {
                return NotFound("không tìm thấy tài khoản ");
            }
            return Ok(teller);
        }

    }
}
