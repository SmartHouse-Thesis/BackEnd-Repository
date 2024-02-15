using Application.Services;
using Application.UseCase.Sercurity;
using AutoMapper;
using Domain.DTOs.Request.Post;
using Domain.DTOs.Request.Put;
using Domain.DTOs.Response;
using Domain.Entities;
using Infrastructure;
using Microsoft.AspNetCore.Authentication.JwtBearer;
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
        private readonly ILogger<AccountController> _logger;
        private readonly CustomerService _customerService;
        private readonly StaffService _staffService;
        private readonly TellerService _tellerService;
        private readonly OwnerService _ownerService;

        public AccountController(AccountService accountService, IMapper mapper, RoleService roleService, PasswordHash passwordHash,CustomerService customerService,StaffService staffService , TellerService tellerService, OwnerService ownerService,ILogger<AccountController> logger)
        {
            _accountService = accountService;
            _mapper = mapper;
            _roleService = roleService;
            _passwordHash = passwordHash;
            _logger = logger;
            _customerService = customerService;
            _staffService = staffService;
            _tellerService = tellerService;
            _ownerService = ownerService;
        }

        [HttpPost("login")]
        //[ProducesResponseType(typeof(List<AccountViewModel>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(AuthenResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(AuthenResponse), StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> Login([FromBody] LoginRequest model)
        {
            try
            {
                var account = _accountService.Authenticate(model.Email, model.Password);
                if (account == null)
                {
                    return Unauthorized(new AuthenResponse { Message = "Invalid username or password" });
                }
                else
                {
                    // Tạo và trả về token JWT
                    string token = _passwordHash.GenerateJwtToken(await account);
                    //handle cookie 
                    var cookieOptions = new CookieOptions
                    {
                        HttpOnly = true,
                        Secure = true,
                        MaxAge = TimeSpan.FromDays(1),
                    };
                    Response.Cookies.Append("accessToken", token, cookieOptions);

                    return Ok(new AuthenResponse { Token = token, Message = "Login Success" });
                }
            } catch (Exception ex) {
                return BadRequest( new AuthenResponse { Message="Error Login!! "});
            }            
        }

        [Authorize]
        [HttpPost("logout")]
        public async Task<IActionResult> Logout()
        {
            // Đưa ra các xử lý đăng xuất nếu cần thiết
            try
            {
                Response.Cookies.Delete("accessToken");
                return Ok(new { message = "Logout successful" });
            }
            catch
            {
                throw new Exception("logout Error ");
            }
        }

       /* ///Hàm gen Token
        private string GenerateJwtToken(Account account)
        {
            if (account == null)
            {
                throw new ArgumentNullException(nameof(account));
            }
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("SS590Z/hUu8cjD9w4W51xA==")); // fix cứng chưa verify với construct                             
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            // lấy role từ role Id 
            var role = _roleService.GetRole(account.RoleId);
            var claims = new List<Claim>
     {
         new Claim(ClaimTypes.Name, account.FirstName), // tên 
         new Claim(ClaimTypes.GivenName, account.LastName), //tên chính thức 
         new Claim(ClaimTypes.Email, account.Email), // email
         new Claim(ClaimTypes.NameIdentifier, account.Id.ToString()), // Thêm ID người dùng vào claim
         new Claim(ClaimTypes.Role, role.Result.RoleName),// Sử dụng RoleName từ bảng Role
         new Claim(ClaimTypes.StreetAddress, account.Address)
     };

            var token = new JwtSecurityToken(
                issuer: "ISHE",
                audience: "ISHE",
                claims: claims,
                expires: DateTime.Now.AddHours(1),
                signingCredentials: credentials
            );
            return new JwtSecurityTokenHandler().WriteToken(token);
        }*/

        [Authorize(Roles ="Owner")]
        // GET: api/<AccountController>/GettAllAccount
        [HttpGet("get-all-account")]
        [ProducesResponseType(typeof(Account), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(AuthenResponse), StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> GettAllAccount()
        {
            try
            {
                var account = await _accountService.GetAll();
                //var _account = _mapper.Map<ListStaffResponse>(account);
                return Ok(account);
            } catch (Exception ex)
            {
                _logger.LogError(ex, "Error in GettAllAccount");
                return StatusCode(403, "Forbiden ");
            }
        }

        [Authorize(Roles = "Owner")]
        [HttpGet("get-all-staff-account")]
        public async Task<IActionResult> GetAllStaffAccount()
        {
            try
            {
                var accounts = await _accountService.GetAll();
                var liststaff = new List<StaffResponse>();
                foreach (Account account in accounts)
                {
                    if(account.Role.RoleName != "Owner" && account.Role.RoleName != "Customer")
                    {
                        var staff = _mapper.Map<StaffResponse>(account);
                        liststaff.Add(staff);
                    }
                }
                return Ok(liststaff);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error in GettAllAccount");
                return StatusCode(500, "Internal Server Error");
            }
        }

        [Authorize(Roles = "Owner, Teller, Customer, Staff")]
        // GET api/<AccountController>/GetAccout/5
        [HttpGet("get-account/{id}")]
        [ProducesResponseType(typeof(AccountResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(AuthenResponse), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(AuthenResponse), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetAccount(Guid id)
        {
            try
            {
                var account = await _accountService.GetAccount(id);
                if (account == null)
                {
                    return NotFound( new AuthenResponse { Message ="Account Does Exist"});
                }
                var _account = _mapper.Map<AccountResponse>(account);
                return Ok(_account);
            }
            catch (Exception ex)
            {
                return StatusCode(403, "forbiden");
            }
           
        }


        // POST api/<AccountController>/CreateAccount/
        [HttpPost("register")] 
        [ProducesResponseType(typeof(RegisterResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(AuthenResponse), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(AuthenResponse), StatusCodes.Status403Forbidden)]
        public async Task<IActionResult> CreateCustomer([FromBody] RegisterRequest account)
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
                _account.Role = Role;
                _account.RoleId = Role.Id;
                await _customerService.CreateCustomer(_account);

                return Ok(new RegisterResponse
                {
                    Message ="Create Customer Success",
                    Id = _account.Id
                });
            }
        }

        [Authorize(Roles = "Owner")]
        [HttpPost("create-staff")]
        [ProducesResponseType(typeof(RegisterResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(AuthenResponse), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(AuthenResponse), StatusCodes.Status403Forbidden)]
        public async Task<IActionResult> CreateStaff([FromBody] RegisterRequest account)
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
                _account.Password = _passwordHash.HashPassword(account.Password); //hashPassword
                var Role = await _roleService.getRoleByRoleName("Staff");
                _account.Role = Role;
                _account.RoleId = Role.Id;
                await _staffService.CreateStaff(_account);

                return Ok(new RegisterResponse
                {
                    Message = "Create Staff Success",
                    Id = _account.Id
                });
            }
        }

        [Authorize(Roles = "Owner")]
        [HttpPost("create-teller")]
        [ProducesResponseType(typeof(RegisterResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(AuthenResponse), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(AuthenResponse), StatusCodes.Status403Forbidden)]
        public async Task<IActionResult> CreateTeller([FromBody] RegisterRequest account)
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
                _account.Password = _passwordHash.HashPassword(account.Password); //hashPassword
                var Role = await _roleService.getRoleByRoleName("Teller");
                _account.Role = Role;
                _account.RoleId = Role.Id;
                await _tellerService.CreateTeller(_account);

                return Ok(new RegisterResponse
                {
                    Message = "Create Teller Success",
                    Id = _account.Id
                });
            }
        }

        //[Authorize(Roles = "Owner")]
        [HttpPost("create-owner")]
        [ProducesResponseType(typeof(RegisterResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(AuthenResponse), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(AuthenResponse), StatusCodes.Status403Forbidden)]
        public async Task<IActionResult> CreateOwner([FromBody] RegisterRequest account)
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
                _account.Password = _passwordHash.HashPassword(account.Password); //hashPassword
                var Role = await _roleService.getRoleByRoleName("Owner");
                _account.Role = Role;
                _account.RoleId = Role.Id;
                await _ownerService.CreateOwner(_account);

                return Ok(new RegisterResponse
                {
                    Message = "Create Teller Success",
                    Id = _account.Id
                });
            }
        }

        [Authorize(Roles = "Owner, Customer, Teller, Staff")]
        // PUT api/<AccountController>/UpdateAccount/5
        [HttpPut("update-account/{id}")]
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


        [Authorize(Roles = "Owner")]
        // DELETE api/<AccountController>/Delete/5
        [HttpDelete("delete-account/{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            try
            {
                var _account = await _accountService.GetAccount(id);
                if (_account != null)
                {
                    _account.IsDelete = true;
                    await _accountService.UpdateAccount(_account);
                    return Ok("Remove Success");
                }
                else
                {
                    return NotFound("Account Doesnt Exist !!");
                }
            } catch (Exception ex)
            {
                _logger.LogError(ex, "delete-account");
                return StatusCode(500, "delete-account_Error");
            }          
        }

        //
    }
}
