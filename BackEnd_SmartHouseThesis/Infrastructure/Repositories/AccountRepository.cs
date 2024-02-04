using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class AccountRepository : BaseRepo<Account>
    {
        public AccountRepository(AppDbContext dbContext, ILogger<BaseRepo<Account>> logger) : base(dbContext, logger)
        {
            _dbContext = dbContext;
            _logger = logger;
        }
        public AccountRepository(AppDbContext dbContext) : base(dbContext)
        {

        }
        private readonly AppDbContext _dbContext;
        private readonly ILogger<BaseRepo<Account>> _logger;
        public async Task<Account> GetAccountByEmail(string email)
        {
            try
            {
                Account item = await _dbContext.Set<Account>().FirstOrDefaultAsync(a =>a.Email == email);
                return item;
            }
            catch (Exception e)
            {
                _logger.LogError(e, "{Repo} GetAccountByEmailAsync function error", typeof(BaseRepo<Account>));
                return null;
            }
        }
        public Account Authenticate(string email, string password)
        {
            var account =  _dbContext.Accounts.SingleOrDefault(a => a.Email == email && a.Password == password);

            if (account != null)
            {
                account.Role =  _dbContext.Role.SingleOrDefault(r => r.Id == account.RoleId);
            }

            return account;
        }
/*
        private string generateJwtToken(Account user)
        {
            // generate token that is valid for 7 days
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.UTF32.GetBytes();
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[] { new Claim("id", user.Id.ToString()) }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }*/



    }
}
