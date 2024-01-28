using Application.Services;
using Application.UseCase;
using AutoMapper;
using Domain.DTOs.Request;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BackEnd_SmartHouseThesis.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly CustomerService _customerService;
        private readonly AccountService _accountService;
        private readonly RoleService _roleService;
        private readonly IMapper _mapper;
        public CustomerController(CustomerService customerService, AccountService accountService, RoleService roleService, IMapper mapper)
        {
            _customerService = customerService;
            _mapper = mapper;
            _accountService = accountService;
            _roleService = roleService;
        }

        // GET: api/<CustomerController>/GetAllCustomer
        [HttpGet("GetAllCustomer")]
        public async Task<IActionResult> GetAllCustomer()
        {
            var customer = await _customerService.GetAll();
            return Ok(customer);
        }

        // GET api/<CustomerController>/GetCustomer/5
        [HttpGet("GetCustomer/{id}")]
        public async Task<IActionResult> GetCustomer(Guid id)
        {
            var owner = await _customerService.GetCustomer(id);
            if (owner == null)
            {
                return NotFound();
            }
            return Ok(owner);
        }

        // POST api/<CustomerController>/CreateCustomer/{accountId}
        [HttpPost("CreateCustomer/{accountId}")]
        public async Task<IActionResult> CreateCustomer(Guid accountId)
        {
            var _account = await _accountService.GetAccount(accountId);
            if (_account != null)
            {
                var role = await _roleService.GetRole(_account.RoleId);
                if (role.Id == _account.RoleId)
                {
                    var customer = _mapper.Map<Customer>(_account);
                    await _customerService.CreateCustomer(customer);
                    return Ok(customer);
                }
                else
                {
                    return BadRequest("Can't do this right now");
                }
            }
            else
            {
                return BadRequest("Account doesnt exist");
            }
        }

        // POST api/<CustomerController>/CreateCustomer/{accountId}
        [HttpPost("CreateCustomer/{accountId}")]
        public async Task<IActionResult> RegisterAccount([FromBody] RegisterRequest account)
        {
            var _account = await _accountService.GetAccountByEmail(account.Email);
            if (_account != null) 
            {
                var role = await _roleService.GetRole(_account.RoleId);
                if (role.RoleName == account.RoleName)
                {
                    var customer = _mapper.Map<Customer>(_account);
                    await _customerService.CreateCustomer(customer);
                    return Ok(customer);
                }
                else
                {
                    return BadRequest("Account use in another Role !!");
                }
            }
            else // account chưa có 
            {
                var _newAccount = _mapper.Map<Account>(account);
                await _accountService.CreateAccount(_newAccount); // tạo mới account 
                var _customerAccount = _mapper.Map<Customer>(_newAccount);
                await _customerService.CreateCustomer(_customerAccount); // có account tạo mới customer 
                return Ok(_customerAccount);
            }
        }
    }
}
