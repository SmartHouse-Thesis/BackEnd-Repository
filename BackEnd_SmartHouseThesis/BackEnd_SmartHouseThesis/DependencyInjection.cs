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
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(option =>
                {
                    option.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        ValidIssuer = configuration["JwtIssuer"],
                        ValidAudience = configuration["JwtAudience"],
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JwtSecurityKey"]))
                    };
                });

        }
    }
}
