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
        public DbSet<Contract> Contracts { get; set; } = null!;
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
        public DbSet<Teller> Tellers { get; set; } = null!;

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

            modelBuilder.Entity<Role>().HasData(
                new Role { Id = Guid.NewGuid(), RoleName="Owner" },
                new Role { Id = Guid.NewGuid(), RoleName = "Staff" },
                new Role { Id = Guid.NewGuid(), RoleName = "Teller" },
                new Role { Id = Guid.NewGuid(), RoleName = "Customer" }
                );
            

            // one-to-one 
            //Account - Cus,Owner,Staff,Teller
            modelBuilder.Entity<Customer>()
                .HasOne(c => c.Account)
                 .WithOne(a => a.Customer)         
                .HasForeignKey<Customer>(c => c.Id);

            modelBuilder.Entity<Owner>()
                .HasOne(o => o.Account)
                 .WithOne(a => a.Owner)
                .HasForeignKey<Owner>(o => o.Id);

            modelBuilder.Entity<Staff>()
                .HasOne(s => s.Account)
                 .WithOne(a => a.Staff)
                .HasForeignKey<Staff>(s => s.Id);

            modelBuilder.Entity<Teller>()
                .HasOne(t => t.Account)
                 .WithOne(a => a.Teller)
                .HasForeignKey<Teller>(t => t.Id);

            //Survey-Request
            modelBuilder.Entity<Survey>()
                .HasOne(s => s.Request)
                 .WithOne(r => r.Survey)
                .HasForeignKey<Survey>(c => c.RequestId);

            modelBuilder.Entity<Request>()
               .HasOne(s => s.Survey)
                .WithOne(r => r.Request)
               .HasForeignKey<Request>(c => c.SurveyId);

            //Constract-Acceptance
            modelBuilder.Entity<Contract>()
                .HasOne(c => c.Acceptance)
                 .WithOne(a => a.Contract)
                .HasForeignKey<Contract>(c => c.AcceptanceId);

            modelBuilder.Entity<Acceptance>()
               .HasOne(a => a.Contract)
                .WithOne(c => c.Acceptance)
               .HasForeignKey<Acceptance>(c => c.ContractId);

            //Package-Image
            modelBuilder.Entity<Package>()
                   .HasOne(p => p.Image)
                   .WithOne(i => i.Package)
                   .HasForeignKey<Package>(c => c.ImageId);

            modelBuilder.Entity<Image>()
                .HasOne(i=>i.Package)
                .WithOne(p=>p.Image)
                .HasForeignKey<Image>(c => c.PackageId);

            //Order-OrderDetail
            modelBuilder.Entity<OrderDetail>()
               .HasOne(o => o.Order)
                .WithOne(a => a.OrderDetail)
               .HasForeignKey<OrderDetail>(o => o.Id);

            //Packge - Manufacturer 
            modelBuilder.Entity<Package>()
                   .HasOne(p => p.Manufacturer)
                   .WithOne(i => i.Package)
                   .HasForeignKey<Package>(c => c.ManufacturerId);

            modelBuilder.Entity<Manufacturer>()
                .HasOne(i => i.Package)
                .WithOne(p => p.Manufacturer)
                .HasForeignKey<Manufacturer>(c => c.PackageId);

            //Packge - Policy 
            modelBuilder.Entity<Package>()
                   .HasOne(p => p.Policy)
                   .WithOne(i => i.Package)
                   .HasForeignKey<Package>(c => c.PolicyId);

            modelBuilder.Entity<Policy>()
                .HasOne(i => i.Package)
                .WithOne(p => p.Policy)
                .HasForeignKey<Policy>(c => c.PackageId);

            //Acceptance-WarrantyReport
            /* 
            modelBuilder.Entity<Acceptance>()
                .HasOne(a => a.WarrantyReport)
                .WithOne(w => w.Acceptance)
                .HasForeignKey<Acceptance>(c => c.WarrantyId);

            modelBuilder.Entity<WarrantyReport>()
                .HasOne(w => w.Acceptance)
                .WithOne(a => a.WarrantyReport)
                .HasForeignKey<WarrantyReport>(c => c.AcceptanceId);*/

            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }


}
