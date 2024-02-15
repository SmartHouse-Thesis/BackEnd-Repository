using Application.Services;
using Domain.Constants;
using Domain.DTOs.Request.Post;
using Domain.DTOs.Response;
using Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace BackEnd_SmartHouseThesis.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        public AuthenticationController()
        {
        }

        [HttpGet("get-info")]
        [Authorize]
        public async Task<IActionResult> getAccountInformation()
        {
            // Lấy token từ header ủy quyền
            var token = Request.Headers["Authorization"].ToString().Replace("Bearer ", "");

            // Giải mã token
            var handler = new JwtSecurityTokenHandler();
            var jwtToken = handler.ReadJwtToken(token);

            // Lấy giá trị NameIdentifier
            var nameIdentifier = jwtToken.Claims.First(c => c.Type == ClaimTypes.NameIdentifier).Value;
            var firtName = jwtToken.Claims.First(c => c.Type == ClaimTypes.Name).Value;
            var LastName = jwtToken.Claims.First(c => c.Type == ClaimTypes.GivenName).Value;
            var email = jwtToken.Claims.First(c => c.Type == ClaimTypes.Email).Value;
            var role = jwtToken.Claims.First(c => c.Type == ClaimTypes.Role).Value;
            var address = jwtToken.Claims.First(c => c.Type == ClaimTypes.StreetAddress).Value;
            //var Phone = jwtToken.Claims.First(c => c.Type == ClaimTypes.NameIdentifier).Value;
            return Ok(new AccountInfoResponse{
                Id = nameIdentifier, 
                Email = email,
                FirstName = firtName,
                LastName = LastName, 
                Address = address,
                RoleName = role
            });
        }
/*
        [HttpPost("revoke-token")]
        [Authorize]
        public async Task<IActionResult> RevokeToken()
        {
            // Trích xuất ID người dùng từ yêu cầu được ủy quyền:
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            // Truy vấn mã thông báo làm mới từ ngữ cảnh/lưu trữ người dùng (nếu có liên quan):
            // var refreshToken = ...

            // Hủy hiệu lực mã thông báo của người dùng trong danh sách đen:
            await RevokeUserTokens(userId, refreshToken);

            return Ok(new { Message = "Mã thông báo đã được hủy thành công" });
        }
*/

    }
}

