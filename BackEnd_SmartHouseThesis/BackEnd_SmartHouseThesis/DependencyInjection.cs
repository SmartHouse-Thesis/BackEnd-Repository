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
using Application.UseCase.Sercurity;

namespace BackEnd_SmartHouseThesis
{
    public static class DependencyInjection
    {
        public static void ConfigureServices(this IServiceCollection services)
        {
            services.AddDbContext<AppDbContext>();
            services.AddScoped<AppDbContext>();
            services.AddSignalR();
            ///AddService
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
            //Policy
            services.AddScoped<PolicyService>();
            services.AddScoped<PolicyRepository>();
            //Teller
            services.AddScoped<TellerService>();
            services.AddScoped<TellerRepository>();
            //Customer
            services.AddScoped<CustomerService>();
            services.AddScoped<CustomerRepository>();
            //Staff
            services.AddScoped<StaffService>();
            services.AddScoped<StaffRepository>();
            //Feedback 
            services.AddScoped<FeedbackService>();
            services.AddScoped<FeedbackRepository>();
            //Survey
            services.AddScoped<SurveyService>();
            services.AddScoped<SurveyRepository>();
            //PasswordHash
            services.AddScoped<PasswordHash>();
        }

        public static void AutoMapper(this IServiceCollection services)
        {
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            services.AddAutoMapper(typeof(AccountMappingProfile));
            services.AddAutoMapper(typeof(PromotionMapping));
            services.AddAutoMapper(typeof(DeviceMapping));
            services.AddAutoMapper(typeof(PackageMapping));
            services.AddAutoMapper(typeof(PolicyMapping));
            services.AddAutoMapper(typeof(ManufacturerMappingProfile));
            services.AddAutoMapper(typeof(SurveyMappingProfile));
        }


    }
}
