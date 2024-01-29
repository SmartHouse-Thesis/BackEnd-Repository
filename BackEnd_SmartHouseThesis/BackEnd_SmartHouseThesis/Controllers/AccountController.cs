using Application.Services;
using Application.UseCase.Sercurity;
using AutoMapper;
using Domain.DTOs.Request;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BackEnd_SmartHouseThesis.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly AccountService _accountService;
        private readonly RoleService _roleService; 
        private readonly IMapper _mapper;
        private readonly PasswordHash _passwordHash;
        public AccountController(AccountService accountService, IMapper mapper, RoleService roleService, PasswordHash passwordHash)
        {
            _accountService = accountService;
            _mapper = mapper;
            _roleService = roleService;
            _passwordHash = passwordHash;
        }

        // GET: api/<AccountController>/GettAllAccount
        [HttpGet("GettAllAccount")]
        public async Task<IActionResult> GettAllAccount()
        {
            var account = await _accountService.GetAll();
            return Ok(account);
        }

        // GET api/<AccountController>/GetAccout/5
        [HttpGet("GetAccout/{id}")]
        public async Task<IActionResult> GetAccout(Guid id)
        {
            var account = await _accountService.GetAccount(id);
            if (account == null)
            {
                return NotFound();
            }
            return Ok(account);
        }

        // POST api/<AccountController>/CreateAccount/
        [HttpPost("CreateAccount")] 
        public async Task<IActionResult> CreateAccount([FromBody] RegisterRequest account)
        {
            var _account = await _accountService.GetAccountByEmail(account.Email);
            if (_account != null)
            { 
                return BadRequest("Account is exist!! ");
            }
            else
            {
                _account = _mapper.Map<Account>(account);
                _account.CreationDate = DateTime.Now;
                _account.Password = _passwordHash.HashPassword(account.Password);
                var Role = await _roleService.getRoleByRoleName("Customer");
                _account.RoleId = Role.Id;
                await _accountService.CreateAccount(_account);
                return Ok(_account);
            }
        }

        // PUT api/<AccountController>/UpdateAccount/5
        [HttpPut("UpdateAccount/{id}")]
        public async Task<IActionResult> UpdateAccount(Guid id, [FromBody] AccountUpdate account)
        {
            var _account = await _accountService.GetAccount(id);
            if (_account != null)
            {                
                var accountUpdate = _mapper.Map<Account>(account);
                await _accountService.UpdateAccount(accountUpdate);
                return Ok(accountUpdate);
            }
            else
            {
                return NotFound("Account Doesnt Exist !!");
            }
        }

        // DELETE api/<AccountController>/Delete/5
        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var _account = await _accountService.GetAccount(id);
            if (_account != null)
            {
                await _accountService.DeleteAccount(_account);
                return Ok("Remove Success");
            }
            else
            {
                return NotFound("Account Doesnt Exist !!");
            }
        }

        //
    }
}
