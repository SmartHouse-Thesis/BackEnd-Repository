using Application.Services;
using BackEnd_SmartHouseThesis.Controllers;
using Infrastructure;
using Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);
// Add services to the container.
builder.Services.AddDbContext<AppDbContext>();
builder.Services.AddScoped<AppDbContext>();
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
builder.Services.AddScoped <PackageRepository>();
//Policy
builder.Services.AddScoped<PolicyService>();
builder.Services.AddScoped<PolicyRepository>();
//Promotion
builder.Services.AddScoped<PromotionService>();
builder.Services.AddScoped<PromotionRepository>();
//Account
builder.Services.AddScoped<AccountService>();
builder.Services.AddScoped<AccountRepository>();


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

app.UseAuthorization();

app.MapControllers();

app.Run();
