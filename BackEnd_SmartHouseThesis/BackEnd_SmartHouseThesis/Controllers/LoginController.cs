using Domain.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BackEnd_SmartHouseThesis.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private IConfiguration _config;

        public LoginController (IConfiguration config)
        {
            _config = config;
        }

        private Authen AuthenticateAccount(Authen authen)
        {
            Authen _authen = null;
            if (authen.Email == "admin" && authen.Password == "123")
            {
                _authen = new Authen { Email = "admin" };

            }
            return _authen;
        }

        private string GenerateToken(Authen authen)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(_config["Jwt:Issuer"], _config["Jwt:Audience"], null,
                expires: DateTime.Now.AddMinutes(1), signingCredentials: credentials);
            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        // POST api/<LoginController>/Login/
        [AllowAnonymous]
        [HttpPost]
        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody] Authen authen)
        {
            IActionResult response = Unauthorized();
            var user = AuthenticateAccount(authen);
            if (user != null)
            {
                var token = GenerateToken(authen);
                response = Ok(new { token = token });
            }
            return response;
        }


    }
}
