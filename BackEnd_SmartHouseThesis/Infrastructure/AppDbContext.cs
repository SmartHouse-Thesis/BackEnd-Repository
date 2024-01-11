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
        public DbSet<Acceptance> Acceptances { get; set; } = null!;
        public DbSet<Account> Accounts { get; set; } = null!;
        public DbSet<Chat> Chats { get; set; } = null!;
        public DbSet<Constract> Constracts { get; set; } = null!;
        public DbSet<Customer> Customers { get; set; } = null!;
        public DbSet<Device> Device { get; set; } = null!;
        public DbSet<Feedback> Feedbacks { get; set; } = null!;
        public DbSet<Image> Image { get; set; } = null!;
        public DbSet<Owner> Owner { get; set; } = null!;
        public DbSet<Package> Packages { get; set; } = null!;
        public DbSet<Payment> Payment { get; set; } = null!;
        public DbSet<Promotion> Promotion { get; set; } = null!;
        public DbSet<Request> Requests { get; set; } = null!;
        public DbSet<Revenue> Revenues { get; set; } = null!;
        public DbSet<Role> Role { get; set; } = null!;
        public DbSet<Staff> Staff { get; set; } = null!;
        public DbSet<Survey> Surveys { get; set; } = null!;
        public DbSet<Team> Team { get; set; } = null!;
        public DbSet<Teller> Tellers { get; set; } = null!;
        public DbSet<WarrantyReport> WarrantyReport { get; set; } = null!;
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
            modelBuilder.Entity<Customer>()
                .HasOne(c => c.Account)
                 .WithOne(a => a.Customer)
                .HasForeignKey<Customer>(c => c.Id);

            modelBuilder.Entity<Owner>()
                .HasOne(c => c.Account)
                 .WithOne(a => a.Owner)
                .HasForeignKey<Owner>(c => c.Id);

            modelBuilder.Entity<Staff>()
                .HasOne(c => c.Account)
                 .WithOne(a => a.Staff)
                .HasForeignKey<Staff>(c => c.Id);

            modelBuilder.Entity<Teller>()
                .HasOne(c => c.Account)
                 .WithOne(a => a.Teller)
                .HasForeignKey<Teller>(c => c.Id);

            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }


}
