using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SmartHouseBE.Entities;
using SmartHouseBE.Models;

namespace SmartHouseBE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly SmartHomeContext _smartHomeContext;

        public UsersController(SmartHomeContext smarthomeContext)
        {
            _smartHomeContext = smarthomeContext;
        }

        [HttpPost("Login")]
        public async Task<ActionResult<User>> Login(Login login)
        {
            var user = (from u in _smartHomeContext.Users
                        join r in _smartHomeContext.Roles on u.RoleId equals r.Id
                        where u.UserName == login.UserName && u.Password == login.Password
                        select new UserEntity
                        {
                            Id = u.Id,
                            UserName = u.UserName,
                            Password = u.Password,
                            Email = u.Email,
                            CreatedTime = u.CreatedDate,
                            Address = u.Address,
                            FirstName = u.FirstName,
                            LastName = u.LastName,
                            Role = r.RoleName
                        }).FirstOrDefault();
            if (user == null)
                return await Task.FromResult(NotFound(new { Status = "Fail", Message = "Username or Password is incorrect" }));

            return await Task.FromResult(Ok(new { Status = "Success", Message = "Login successfully", User = user.FirstName + " " +user.LastName }));
        }

    }
}
