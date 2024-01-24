using Application.Services;
using BackEnd_SmartHouseThesis;
using Infrastructure;
using Infrastructure.Mapper;
using Infrastructure.Repositories;


var builder = WebApplication.CreateBuilder(args);
// Add services to the container.
builder.Services.AddDbContext<AppDbContext>();
builder.Services.AddScoped<AppDbContext>();

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

/*
builder.Services.AddIdentity<Account, Role>();
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
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
});*/

//builder.Services.ConfigureServices(builder.Configuration);


builder.Services.AddHttpContextAccessor();
builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();
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
