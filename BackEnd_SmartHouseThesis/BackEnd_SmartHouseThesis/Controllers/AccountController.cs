using Application.Services;
using Application.UseCase.Sercurity;
using AutoMapper;
using Domain.DTOs.Request.Post;
using Domain.DTOs.Request.Put;
using Domain.DTOs.Response;
using Domain.Entities;
using Infrastructure;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.Configuration;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Principal;
using System.Text;

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

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequest model)
        {
            
            var account = _accountService.Authenticate(model.Email, model.Password);

            if (account == null)
            {
                return Unauthorized(new AuthenResponse{ Message = "Invalid username or password" });
            }
            else
            {
                // Tạo và trả về token JWT

                string token = GenerateJwtToken(account);
                return Ok(new AuthenResponse { Token =token });
            }                    
        }

        [Authorize]
        [HttpPost("logout")]
        public async Task<IActionResult> Logout()
        {
            // Đưa ra các xử lý đăng xuất nếu cần thiết
            return Ok(new { message = "Logout successful" });
        }

        ///Hàm gen Token
        private string GenerateJwtToken(Account account)
        {
            if (account == null)
            {
                throw new ArgumentNullException(nameof(account));
            }
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("SS590Z/hUu8cjD9w4W51xA==")); // fix cứng chưa verify với construct
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new List<Claim>
    {
        new Claim(ClaimTypes.Name, account.Email),
        new Claim(ClaimTypes.NameIdentifier, account.Id.ToString()), // Thêm ID người dùng vào claim
        new Claim(ClaimTypes.Role, account.Role.RoleName) // Sử dụng RoleName từ bảng Role
    };

            var token = new JwtSecurityToken(
                issuer: "ISHE",
                audience: "ISHE",
                claims: claims,
                expires: DateTime.Now.AddHours(1),
                signingCredentials: credentials
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }




        // GET: api/<AccountController>/GettAllAccount
        [Authorize(Roles = "Owner,Customer")]
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

        [Authorize(Roles = "Owner")]
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
