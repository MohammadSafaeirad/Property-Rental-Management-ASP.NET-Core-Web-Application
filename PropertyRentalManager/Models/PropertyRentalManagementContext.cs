using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace PropertyRentalManager.Models
{
    public partial class PropertyRentalManagementContext : DbContext
    {
        public PropertyRentalManagementContext()
        {
        }

        public PropertyRentalManagementContext(DbContextOptions<PropertyRentalManagementContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Apartment> Apartments { get; set; } = null!;
        public virtual DbSet<Appointment> Appointments { get; set; } = null!;
        public virtual DbSet<Building> Buildings { get; set; } = null!;
        public virtual DbSet<Message> Messages { get; set; } = null!;
        public virtual DbSet<PropertyManager> PropertyManagers { get; set; } = null!;
        public virtual DbSet<PropertyOwner> PropertyOwners { get; set; } = null!;
        public virtual DbSet<Report> Reports { get; set; } = null!;
        public virtual DbSet<Status> Statuses { get; set; } = null!;
        public virtual DbSet<Tenant> Tenants { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;
        public virtual DbSet<UserType> UserTypes { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Apartment>(entity =>
            {
                entity.Property(e => e.ApartmentId).HasColumnName("ApartmentID");

                entity.Property(e => e.BuildingId).HasColumnName("BuildingID");

                entity.Property(e => e.StatusId).HasColumnName("StatusID");

                entity.HasOne(d => d.Building)
                    .WithMany(p => p.Apartments)
                    .HasForeignKey(d => d.BuildingId)
                    .HasConstraintName("FK_ApartmentBuilding");

                entity.HasOne(d => d.Status)
                    .WithMany(p => p.Apartments)
                    .HasForeignKey(d => d.StatusId)
                    .HasConstraintName("FK_ApartmentStatus");
            });

            modelBuilder.Entity<Appointment>(entity =>
            {
                entity.Property(e => e.AppointmentId).HasColumnName("AppointmentID");

                entity.Property(e => e.AppointmentDate).HasColumnType("date");

                entity.Property(e => e.ManagerId).HasColumnName("ManagerID");

                entity.Property(e => e.TenantId).HasColumnName("TenantID");

                entity.HasOne(d => d.Manager)
                    .WithMany(p => p.Appointments)
                    .HasForeignKey(d => d.ManagerId)
                    .HasConstraintName("FK_AppointmentManager");

                entity.HasOne(d => d.Tenant)
                    .WithMany(p => p.Appointments)
                    .HasForeignKey(d => d.TenantId)
                    .HasConstraintName("FK_AppointmentTenant");
            });

            modelBuilder.Entity<Building>(entity =>
            {
                entity.Property(e => e.BuildingId).HasColumnName("BuildingID");

                entity.Property(e => e.Address)
                    .HasMaxLength(70)
                    .IsUnicode(false);

                entity.Property(e => e.City)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.State)
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.ZipCode)
                    .HasMaxLength(6)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Message>(entity =>
            {
                entity.Property(e => e.MessageId).HasColumnName("MessageID");

                entity.Property(e => e.DateSent).HasColumnType("date");

                entity.Property(e => e.ManagerId).HasColumnName("ManagerID");

                entity.Property(e => e.MessageBody)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Sender)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.TenantId).HasColumnName("TenantID");

                entity.HasOne(d => d.Manager)
                    .WithMany(p => p.Messages)
                    .HasForeignKey(d => d.ManagerId)
                    .HasConstraintName("FK_MessageManager");

                entity.HasOne(d => d.Tenant)
                    .WithMany(p => p.Messages)
                    .HasForeignKey(d => d.TenantId)
                    .HasConstraintName("FK_MessageTenant");
            });

            modelBuilder.Entity<PropertyManager>(entity =>
            {
                entity.HasKey(e => e.ManagerId)
                    .HasName("PK__Property__3BA2AA813D2BB6E0");

                entity.Property(e => e.ManagerId).HasColumnName("ManagerID");

                entity.Property(e => e.BuildingId).HasColumnName("BuildingID");

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.HasOne(d => d.Building)
                    .WithMany(p => p.PropertyManagers)
                    .HasForeignKey(d => d.BuildingId)
                    .HasConstraintName("FK_ManagerBuilding");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.PropertyManagers)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_ManagerUser");
            });

            modelBuilder.Entity<PropertyOwner>(entity =>
            {
                entity.HasKey(e => e.OwnerId)
                    .HasName("PK__Property__81938598E442EBC0");

                entity.Property(e => e.OwnerId).HasColumnName("OwnerID");

                entity.Property(e => e.BuildingId).HasColumnName("BuildingID");

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.HasOne(d => d.Building)
                    .WithMany(p => p.PropertyOwners)
                    .HasForeignKey(d => d.BuildingId)
                    .HasConstraintName("FK_OwnerBuilding");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.PropertyOwners)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_OwnerUser");
            });

            modelBuilder.Entity<Report>(entity =>
            {
                entity.Property(e => e.ReportId).HasColumnName("ReportID");

                entity.Property(e => e.DateSent).HasColumnType("date");

                entity.Property(e => e.ManagerId).HasColumnName("ManagerID");

                entity.Property(e => e.OwnerId).HasColumnName("OwnerID");

                entity.Property(e => e.ReportBody)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.HasOne(d => d.Manager)
                    .WithMany(p => p.Reports)
                    .HasForeignKey(d => d.ManagerId)
                    .HasConstraintName("FK_ReportManager");

                entity.HasOne(d => d.Owner)
                    .WithMany(p => p.Reports)
                    .HasForeignKey(d => d.OwnerId)
                    .HasConstraintName("FK_ReportOwner");
            });

            modelBuilder.Entity<Status>(entity =>
            {
                entity.Property(e => e.StatusId).HasColumnName("StatusID");

                entity.Property(e => e.Description)
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Tenant>(entity =>
            {
                entity.Property(e => e.TenantId).HasColumnName("TenantID");

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Tenants)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_TenantUser");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.Property(e => e.Email)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.FirstName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.LastName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Username)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.UserTypeNavigation)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.UserType)
                    .HasConstraintName("FK_UserType");
            });

            modelBuilder.Entity<UserType>(entity =>
            {
                entity.Property(e => e.UserTypeId).HasColumnName("UserTypeID");

                entity.Property(e => e.UserTypeDescription)
                    .HasMaxLength(10)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
