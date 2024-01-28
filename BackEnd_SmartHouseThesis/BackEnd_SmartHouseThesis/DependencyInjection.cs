using Application.Services;
using Infrastructure.Repositories;
using Infrastructure;
using Domain.Entities;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using System.Configuration;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Infrastructure.Mapper;

namespace BackEnd_SmartHouseThesis
{
    public static class DependencyInjection
    {
        public static void ConfigureServices(this IServiceCollection services, IConfiguration configuration)
        {          
            // Đăng ký DbContext
            services.AddDbContext<AppDbContext>();
            services.AddScoped<AppDbContext>();

            //Account
            services.AddScoped<AccountService>();
            services.AddScoped<AccountRepository>();
            //Owner
            services.AddScoped<OwnerService>();
            services.AddScoped<OwnerRepository>();
            //Device
            services.AddScoped<DeviceService>();
            services.AddScoped<DeviceRepository>();
            //Manufacture
            services.AddScoped<ManufacturerService>();
            services.AddScoped<ManufactureRepository>();
            //Package
            services.AddScoped<PackageServices>();
            services.AddScoped<PackageRepository>();
            //Policy
            services.AddScoped<PolicyService>();
            services.AddScoped<PolicyRepository>();
            //Promotion
            services.AddScoped<PromotionService>();
            services.AddScoped<PromotionRepository>();
            //Account
            services.AddScoped<AccountService>();
            services.AddScoped<AccountRepository>();
            //Contract
            services.AddScoped<ContractService>();
            services.AddScoped<ContractRepository>();
            //Role 
            services.AddScoped<RoleService>();
            services.AddScoped<RoleRepository>();

            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            services.AddAutoMapper(typeof(AccountMappingProfile));
            

            services.AddIdentity<Account, Role>();
            services.AddIdentity<Account, Owner>();
            services.AddIdentity<Account, Staff>();
            services.AddIdentity<Account, Teller>();
            services.AddIdentity<Account, Customer>();

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(o =>
            {
                o.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidIssuer = configuration["Jwt:Issuer"],
                    ValidAudience = configuration["Jwt:Audience"],
                    IssuerSigningKey = new SymmetricSecurityKey
                    (Encoding.UTF8.GetBytes(configuration["Jwt:Key"])),
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = false,
                    ValidateIssuerSigningKey = true
                };
            });

        }
    }
}
