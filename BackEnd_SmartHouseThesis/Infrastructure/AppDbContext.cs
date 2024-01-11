using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            this.ChangeTracker.LazyLoadingEnabled = false;
        }
        public DbSet<Account> Accounts { get; set; } = null!;
        public DbSet<Constract> Constracts { get; set; } = null!;
        public DbSet<Device> Device { get; set; } = null!;
        public DbSet<Promotion> Promotion { get; set; } = null!;
        public DbSet<Role> Role { get; set; } = null!;
        public DbSet<Package> ServicePack { get; set; } = null!;
        public DbSet<Warranty> Warranty { get; set; } = null!;
        public DbSet<Payment> Payment { get; set; } = null!;
        public DbSet<Image> Image { get; set; } = null!;
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            /*if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=localhost,1433;Initial Catalog=SmartHome;User ID=sa;Password=12345");
            }*/
            var builder = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                     .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
            IConfigurationRoot configuration = builder.Build();

            var connectionString = configuration
                        .GetConnectionString("SmartHomeDB");

            optionsBuilder.UseSqlServer(connectionString);

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
