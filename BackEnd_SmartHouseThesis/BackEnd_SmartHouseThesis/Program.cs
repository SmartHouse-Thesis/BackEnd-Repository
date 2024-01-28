using Application.Services;
using SignalRChat.Hubs;
using BackEnd_SmartHouseThesis;
using Domain.Entities;
using Infrastructure;
using Infrastructure.Mapper;
using Infrastructure.Repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;


var builder = WebApplication.CreateBuilder(args);
// Add services to the container.
builder.Services.AddDbContext<AppDbContext>();
builder.Services.AddScoped<AppDbContext>();
builder.Services.AddSignalR();

///AddService
//Account
builder.Services.AddScoped<AccountService>();
builder.Services.AddScoped<AccountRepository>();
//Owner
builder.Services.AddScoped<OwnerService>();
builder.Services.AddScoped<OwnerRepository>();
//Device
builder.Services.AddScoped<DeviceService>();
builder.Services.AddScoped<DeviceRepository>();
//Manufacture
builder.Services.AddScoped<ManufacturerService>();
builder.Services.AddScoped<ManufactureRepository>();
//Package
builder.Services.AddScoped<PackageServices>();
builder.Services.AddScoped<PackageRepository>();
//Policy
builder.Services.AddScoped<PolicyService>();
builder.Services.AddScoped<PolicyRepository>();
//Promotion
builder.Services.AddScoped<PromotionService>();
builder.Services.AddScoped<PromotionRepository>();
//Account
builder.Services.AddScoped<AccountService>();
builder.Services.AddScoped<AccountRepository>();
//Contract
builder.Services.AddScoped<ContractService>();
builder.Services.AddScoped<ContractRepository>();
//Role
builder.Services.AddScoped<RoleService>();
builder.Services.AddScoped<RoleRepository>();

///Mapping
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddAutoMapper(typeof(AccountMappingProfile));
builder.Services.AddAutoMapper(typeof(PromotionMapping));
builder.Services.AddAutoMapper(typeof(DeviceMapping));
builder.Services.AddAutoMapper(typeof(PackageMapping));
builder.Services.AddAutoMapper(typeof(PolicyMapping));
builder.Services.AddAuthentication();
/*builder.Services.AddAuthorization();
builder.Services.AddIdentity<Account,Role>();
builder.Services.AddAuthentication(options =>
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
});*/

//builder.Services.ConfigureServices(builder.Configuration);


builder.Services.AddHttpContextAccessor();
builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();
app.MapHub<ChatHub>("/chatHub");
//////////////////////////////////////////////////////////////////////////////////////////
///Add Cors 
builder.Services.AddCors();



// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

///useCors
app.UseCors(builder =>
{
    builder.AllowAnyOrigin()
           .AllowAnyMethod()
           .AllowAnyHeader();
});

app.UseHttpsRedirection();

///use Routing
app.UseRouting();
///use Authentication
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
