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
        public AccountRepository(AppDbContext dbContext,ILogger<BaseRepo<Account>> logger) : base(dbContext, logger)
        {
            _dbContext = dbContext;
            _logger = logger;

        }
        public AccountRepository(AppDbContext dbContext) : base(dbContext)
        {

        }
        private readonly AppDbContext _dbContext;
        private readonly ILogger<BaseRepo<Account>> _logger;

        /*public async Task<IQueryable<Account>> getAllStaffAccount()
        {
            try
            {
                IQueryable<Account> staffAcc = _dbContext.Set<Account>().AsNoTracking();

                var listStaffAcc = await _dbContext.Set<Account>().Where(a=> a.Role.RoleName != "Customer").ToListAsync();

                 foreach (var staff in listStaffAcc)
                    {
                    staffAcc = staffAcc.Include(staff);
                    }

                //var staffAccount =  FindAllAsync().Result.Where(account => account.Role.RoleName != "Customer");
                return staffAcc;
            } catch (Exception ex)
            {
                return null;
                throw new Exception("Error at getAllStaffAccount");
            }
                    
        }*/

        public async Task<Account> CreateAccount(Account account)
        {
            try
            {
                var acc = await _dbContext.Set<Account>().FirstOrDefaultAsync(a => a.Email == account.Email);
                if (acc == null)
                {
                    account.Id = Guid.NewGuid();
                    await AddAsync(account);
                    Account newAccount = await GetAsync(account.Id);
                    return newAccount;
                }
                return null;
            }
            catch (Exception e)
            {
                _logger.LogError(e, "{Repo} CreateAccount function error", typeof(BaseRepo<Account>));
                throw;
            }
        }


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
