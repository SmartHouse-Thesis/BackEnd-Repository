using Application.Services;
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

        public AccountController(AccountService accountService)
        {
            _accountService = accountService;
        }

        // GET: api/<AccountController>/GettAllAccount
        [HttpGet("GettAllAccount")]
        public async Task<IActionResult> GettAllAccount()
        {
            var devices = await _accountService.GetAll();
            return Ok(devices);
        }

        // GET api/<AccountController>/GetAccout/5
        [HttpGet("GetAccout/{id}")]
        public async Task<IActionResult> GetAccout(Guid id)
        {
            var device = await _accountService.GetAccount(id);
            if (device == null)
            {
                return NotFound();
            }
            return Ok(device);
        }

        // POST api/<AccountController>/CreateAccout/
        [HttpPost("CreateAccout")]
        public async Task<IActionResult> CreateAccout([FromBody] Account account)
        {
            var _account = await _accountService.GetAccount(account.Id);
            if (_account != null)
            {
                return BadRequest("Account is exist!! ");
            }
            else
            {
                await _accountService.CreateAccount(account);
                return Ok();
            }
        }


        // PUT api/<AccountController>/UpdateAccount/5
        [HttpPut("UpdateAccount/{id}")]
        public async Task<IActionResult> UpdateAccount(Guid id, [FromBody] Account account)
        {
            var _account = await _accountService.GetAccount(id);
            if (_account != null)
            {
                await _accountService.UpdateAccount(_account);
                return Ok(_account);
            }
            else
            {
                return BadRequest("Account can't do it right now!! ");
            }
        }

        // DELETE api/<AccountController>/Delete/5
        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var _account = await _accountService.GetAccount(id);
            if (_account != null)
            {
                await _accountService.UpdateAccount(_account);
                return Ok(_account);
            }
            else
            {
                return BadRequest("Account can't do it right now!! ");
            }
        }
    }
}
