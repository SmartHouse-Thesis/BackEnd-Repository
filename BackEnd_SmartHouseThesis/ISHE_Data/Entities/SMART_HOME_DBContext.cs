﻿using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ISHE_Data.Entities
{
    public partial class SMART_HOME_DBContext : DbContext
    {
        public SMART_HOME_DBContext()
        {
        }

        public SMART_HOME_DBContext(DbContextOptions<SMART_HOME_DBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Acceptance> Acceptances { get; set; } = null!;
        public virtual DbSet<Account> Accounts { get; set; } = null!;
        public virtual DbSet<Contract> Contracts { get; set; } = null!;
        public virtual DbSet<ContractDetail> ContractDetails { get; set; } = null!;
        public virtual DbSet<CustomerAccount> CustomerAccounts { get; set; } = null!;
        public virtual DbSet<DevicePackage> DevicePackages { get; set; } = null!;
        public virtual DbSet<DevicePackageUsage> DevicePackageUsages { get; set; } = null!;
        public virtual DbSet<DeviceToken> DeviceTokens { get; set; } = null!;
        public virtual DbSet<FeedbackDevicePackage> FeedbackDevicePackages { get; set; } = null!;
        public virtual DbSet<Image> Images { get; set; } = null!;
        public virtual DbSet<Manufacturer> Manufacturers { get; set; } = null!;
        public virtual DbSet<Notification> Notifications { get; set; } = null!;
        public virtual DbSet<OwnerAccount> OwnerAccounts { get; set; } = null!;
        public virtual DbSet<Payment> Payments { get; set; } = null!;
        public virtual DbSet<Promotion> Promotions { get; set; } = null!;
        public virtual DbSet<Role> Roles { get; set; } = null!;
        public virtual DbSet<SmartDevice> SmartDevices { get; set; } = null!;
        public virtual DbSet<SmartDevicePackage> SmartDevicePackages { get; set; } = null!;
        public virtual DbSet<StaffAccount> StaffAccounts { get; set; } = null!;
        public virtual DbSet<Survey> Surveys { get; set; } = null!;
        public virtual DbSet<SurveyRequest> SurveyRequests { get; set; } = null!;
        public virtual DbSet<TellerAccount> TellerAccounts { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=localhost;Uid=sa;Pwd=12345;Database=SMART_HOME_DB;Persist Security Info=False;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=True;Connection Timeout=30;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Acceptance>(entity =>
            {
                entity.ToTable("Acceptance");

                entity.HasIndex(e => e.ContractId, "UQ__Acceptan__C90D3468042A5A84")
                    .IsUnique();

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.ContractId)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.CreateAt)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(dateadd(hour,(7),getutcdate()))");

                entity.Property(e => e.ImageUrl).IsUnicode(false);

                entity.HasOne(d => d.Contract)
                    .WithOne(p => p.Acceptance)
                    .HasForeignKey<Acceptance>(d => d.ContractId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Acceptanc__Contr__123EB7A3");
            });

            modelBuilder.Entity<Account>(entity =>
            {
                entity.ToTable("Account");

                entity.HasIndex(e => e.PhoneNumber, "UQ__Account__85FB4E38C62B9E9C")
                    .IsUnique();

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.CreateAt)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(dateadd(hour,(7),getutcdate()))");

                entity.Property(e => e.PasswordHash)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.PhoneNumber)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Status).HasMaxLength(100);

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.Accounts)
                    .HasForeignKey(d => d.RoleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Account__RoleId__3A81B327");
            });

            modelBuilder.Entity<Contract>(entity =>
            {
                entity.ToTable("Contract");

                entity.HasIndex(e => e.SurveyId, "UQ__Contract__A5481F7C14AB4145")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.ActualEndDate).HasColumnType("datetime");

                entity.Property(e => e.ActualStartDate).HasColumnType("datetime");

                entity.Property(e => e.CreateAt)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(dateadd(hour,(7),getutcdate()))");

                entity.Property(e => e.EndPlanDate).HasColumnType("datetime");

                entity.Property(e => e.ImageUrl).IsUnicode(false);

                entity.Property(e => e.StartPlanDate).HasColumnType("datetime");

                entity.Property(e => e.Status).HasMaxLength(100);

                entity.Property(e => e.Title).HasMaxLength(255);

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.Contracts)
                    .HasForeignKey(d => d.CustomerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Contract__Custom__7E37BEF6");

                entity.HasOne(d => d.Staff)
                    .WithMany(p => p.Contracts)
                    .HasForeignKey(d => d.StaffId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Contract__StaffI__7C4F7684");

                entity.HasOne(d => d.Survey)
                    .WithOne(p => p.Contract)
                    .HasForeignKey<Contract>(d => d.SurveyId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Contract__Survey__7B5B524B");

                entity.HasOne(d => d.Teller)
                    .WithMany(p => p.Contracts)
                    .HasForeignKey(d => d.TellerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Contract__Teller__7D439ABD");
            });

            modelBuilder.Entity<ContractDetail>(entity =>
            {
                entity.ToTable("ContractDetail");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.ContractId)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.CreateAt)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(dateadd(hour,(7),getutcdate()))");

                entity.Property(e => e.Name).HasMaxLength(255);

                entity.Property(e => e.Type)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.Contract)
                    .WithMany(p => p.ContractDetails)
                    .HasForeignKey(d => d.ContractId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__ContractD__Contr__06CD04F7");

                entity.HasOne(d => d.SmartDevice)
                    .WithMany(p => p.ContractDetails)
                    .HasForeignKey(d => d.SmartDeviceId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__ContractD__Smart__07C12930");
            });

            modelBuilder.Entity<CustomerAccount>(entity =>
            {
                entity.HasKey(e => e.AccountId)
                    .HasName("PK__Customer__349DA5A63CD5B1D8");

                entity.ToTable("CustomerAccount");

                entity.Property(e => e.AccountId).ValueGeneratedNever();

                entity.Property(e => e.Address).HasMaxLength(255);

                entity.Property(e => e.Avatar).IsUnicode(false);

                entity.Property(e => e.Email)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.FullName).HasMaxLength(255);

                entity.Property(e => e.Otp)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.Account)
                    .WithOne(p => p.CustomerAccount)
                    .HasForeignKey<CustomerAccount>(d => d.AccountId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__CustomerA__Accou__4CA06362");
            });

            modelBuilder.Entity<DevicePackage>(entity =>
            {
                entity.ToTable("DevicePackage");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.CreateAt)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(dateadd(hour,(7),getutcdate()))");

                entity.Property(e => e.Name).HasMaxLength(255);

                entity.Property(e => e.Status).HasMaxLength(100);

                entity.HasOne(d => d.Manufacturer)
                    .WithMany(p => p.DevicePackages)
                    .HasForeignKey(d => d.ManufacturerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__DevicePac__Manuf__5DCAEF64");

                entity.HasOne(d => d.Promotion)
                    .WithMany(p => p.DevicePackages)
                    .HasForeignKey(d => d.PromotionId)
                    .HasConstraintName("FK__DevicePac__Promo__5EBF139D");
            });

            modelBuilder.Entity<DevicePackageUsage>(entity =>
            {
                entity.ToTable("DevicePackageUsage");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.ContractId)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.CreateAt)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(dateadd(hour,(7),getutcdate()))");

                entity.Property(e => e.EndWarranty).HasColumnType("datetime");

                entity.Property(e => e.StartWarranty).HasColumnType("datetime");

                entity.HasOne(d => d.Contract)
                    .WithMany(p => p.DevicePackageUsages)
                    .HasForeignKey(d => d.ContractId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__DevicePac__Contr__02084FDA");

                entity.HasOne(d => d.DevicePackage)
                    .WithMany(p => p.DevicePackageUsages)
                    .HasForeignKey(d => d.DevicePackageId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__DevicePac__Devic__02FC7413");
            });

            modelBuilder.Entity<DeviceToken>(entity =>
            {
                entity.ToTable("DeviceToken");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.CreateAt)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(dateadd(hour,(7),getutcdate()))");

                entity.Property(e => e.Token).IsUnicode(false);

                entity.HasOne(d => d.Account)
                    .WithMany(p => p.DeviceTokens)
                    .HasForeignKey(d => d.AccountId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__DeviceTok__Accou__3E52440B");
            });

            modelBuilder.Entity<FeedbackDevicePackage>(entity =>
            {
                entity.ToTable("FeedbackDevicePackage");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.CreateAt)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(dateadd(hour,(7),getutcdate()))");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.FeedbackDevicePackages)
                    .HasForeignKey(d => d.CustomerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__FeedbackD__Custo__66603565");

                entity.HasOne(d => d.DevicePackage)
                    .WithMany(p => p.FeedbackDevicePackages)
                    .HasForeignKey(d => d.DevicePackageId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__FeedbackD__Devic__6754599E");
            });

            modelBuilder.Entity<Image>(entity =>
            {
                entity.ToTable("Image");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.CreateAt)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(dateadd(hour,(7),getutcdate()))");

                entity.Property(e => e.Url).IsUnicode(false);

                entity.HasOne(d => d.DevicePackage)
                    .WithMany(p => p.Images)
                    .HasForeignKey(d => d.DevicePackageId)
                    .HasConstraintName("FK__Image__DevicePac__6B24EA82");

                entity.HasOne(d => d.SmartDevice)
                    .WithMany(p => p.Images)
                    .HasForeignKey(d => d.SmartDeviceId)
                    .HasConstraintName("FK__Image__SmartDevi__6C190EBB");
            });

            modelBuilder.Entity<Manufacturer>(entity =>
            {
                entity.ToTable("Manufacturer");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.CreateAt)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(dateadd(hour,(7),getutcdate()))");

                entity.Property(e => e.Name).HasMaxLength(255);
            });

            modelBuilder.Entity<Notification>(entity =>
            {
                entity.ToTable("Notification");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.CreateAt)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(dateadd(hour,(7),getutcdate()))");

                entity.Property(e => e.Link).HasMaxLength(255);

                entity.Property(e => e.Title).HasMaxLength(255);

                entity.Property(e => e.Type).HasMaxLength(255);

                entity.HasOne(d => d.Account)
                    .WithMany(p => p.Notifications)
                    .HasForeignKey(d => d.AccountId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Notificat__Accou__4F7CD00D");
            });

            modelBuilder.Entity<OwnerAccount>(entity =>
            {
                entity.HasKey(e => e.AccountId)
                    .HasName("PK__OwnerAcc__349DA5A695CB0868");

                entity.ToTable("OwnerAccount");

                entity.Property(e => e.AccountId).ValueGeneratedNever();

                entity.Property(e => e.Avatar).IsUnicode(false);

                entity.Property(e => e.Email)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.FullName).HasMaxLength(255);

                entity.HasOne(d => d.Account)
                    .WithOne(p => p.OwnerAccount)
                    .HasForeignKey<OwnerAccount>(d => d.AccountId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__OwnerAcco__Accou__4222D4EF");
            });

            modelBuilder.Entity<Payment>(entity =>
            {
                entity.ToTable("Payment");

                entity.Property(e => e.Id)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.ContractId)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.CreateAt)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(dateadd(hour,(7),getutcdate()))");

                entity.Property(e => e.Name).HasMaxLength(255);

                entity.Property(e => e.PaymentMethod).HasMaxLength(100);

                entity.Property(e => e.Status).HasMaxLength(100);

                entity.HasOne(d => d.Contract)
                    .WithMany(p => p.Payments)
                    .HasForeignKey(d => d.ContractId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Payment__Contrac__0D7A0286");
            });

            modelBuilder.Entity<Promotion>(entity =>
            {
                entity.ToTable("Promotion");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.CreateAt)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(dateadd(hour,(7),getutcdate()))");

                entity.Property(e => e.EndDate).HasColumnType("datetime");

                entity.Property(e => e.Name).HasMaxLength(255);

                entity.Property(e => e.StartDate).HasColumnType("datetime");

                entity.Property(e => e.Status).HasMaxLength(100);
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.ToTable("Role");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.RoleName).HasMaxLength(50);
            });

            modelBuilder.Entity<SmartDevice>(entity =>
            {
                entity.ToTable("SmartDevice");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.CreateAt)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(dateadd(hour,(7),getutcdate()))");

                entity.Property(e => e.DeviceType).HasMaxLength(255);

                entity.Property(e => e.Name).HasMaxLength(255);

                entity.Property(e => e.Status).HasMaxLength(100);

                entity.HasOne(d => d.Manufacturer)
                    .WithMany(p => p.SmartDevices)
                    .HasForeignKey(d => d.ManufacturerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__SmartDevi__Manuf__59FA5E80");
            });

            modelBuilder.Entity<SmartDevicePackage>(entity =>
            {
                entity.HasKey(e => new { e.SmartDeviceId, e.DevicePackageId })
                    .HasName("PK__SmartDev__BAA2E8EAE9A4AF83");

                entity.ToTable("SmartDevicePackage");

                entity.HasOne(d => d.DevicePackage)
                    .WithMany(p => p.SmartDevicePackages)
                    .HasForeignKey(d => d.DevicePackageId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__SmartDevi__Devic__6383C8BA");

                entity.HasOne(d => d.SmartDevice)
                    .WithMany(p => p.SmartDevicePackages)
                    .HasForeignKey(d => d.SmartDeviceId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__SmartDevi__Smart__628FA481");
            });

            modelBuilder.Entity<StaffAccount>(entity =>
            {
                entity.HasKey(e => e.AccountId)
                    .HasName("PK__StaffAcc__349DA5A643A4A40F");

                entity.ToTable("StaffAccount");

                entity.Property(e => e.AccountId).ValueGeneratedNever();

                entity.Property(e => e.Avatar).IsUnicode(false);

                entity.Property(e => e.Email)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.FullName).HasMaxLength(255);

                entity.HasOne(d => d.Account)
                    .WithOne(p => p.StaffAccount)
                    .HasForeignKey<StaffAccount>(d => d.AccountId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__StaffAcco__Accou__44FF419A");

                entity.HasOne(d => d.StaffLead)
                    .WithMany(p => p.InverseStaffLead)
                    .HasForeignKey(d => d.StaffLeadId)
                    .HasConstraintName("FK__StaffAcco__Staff__45F365D3");
            });

            modelBuilder.Entity<Survey>(entity =>
            {
                entity.ToTable("Survey");

                entity.HasIndex(e => e.SurveyRequestId, "UQ__Survey__07118FED284C509C")
                    .IsUnique();

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.AppointmentDate).HasColumnType("datetime");

                entity.Property(e => e.CreateAt)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(dateadd(hour,(7),getutcdate()))");

                entity.Property(e => e.RoomArea).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.Status).HasMaxLength(100);

                entity.HasOne(d => d.RecommendDevicePackage)
                    .WithMany(p => p.Surveys)
                    .HasForeignKey(d => d.RecommendDevicePackageId)
                    .HasConstraintName("FK__Survey__Recommen__76969D2E");

                entity.HasOne(d => d.SurveyRequest)
                    .WithOne(p => p.Survey)
                    .HasForeignKey<Survey>(d => d.SurveyRequestId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Survey__SurveyRe__75A278F5");
            });

            modelBuilder.Entity<SurveyRequest>(entity =>
            {
                entity.ToTable("SurveyRequest");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.CreateAt)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(dateadd(hour,(7),getutcdate()))");

                entity.Property(e => e.Status).HasMaxLength(100);

                entity.Property(e => e.SurveyDate).HasColumnType("datetime");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.SurveyRequests)
                    .HasForeignKey(d => d.CustomerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__SurveyReq__Custo__6FE99F9F");

                entity.HasOne(d => d.Staff)
                    .WithMany(p => p.SurveyRequests)
                    .HasForeignKey(d => d.StaffId)
                    .HasConstraintName("FK__SurveyReq__Staff__70DDC3D8");
            });

            modelBuilder.Entity<TellerAccount>(entity =>
            {
                entity.HasKey(e => e.AccountId)
                    .HasName("PK__TellerAc__349DA5A6D4B15E42");

                entity.ToTable("TellerAccount");

                entity.Property(e => e.AccountId).ValueGeneratedNever();

                entity.Property(e => e.Avatar).IsUnicode(false);

                entity.Property(e => e.Email)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.FullName).HasMaxLength(255);

                entity.HasOne(d => d.Account)
                    .WithOne(p => p.TellerAccount)
                    .HasForeignKey<TellerAccount>(d => d.AccountId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__TellerAcc__Accou__49C3F6B7");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
