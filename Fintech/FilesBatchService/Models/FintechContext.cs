using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace FilesBatchService.Models
{
    public partial class FintechContext : DbContext
    {

       public FintechContext(DbContextOptions<FintechContext> options)
           : base(options)
        {
        }

        /*protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {

                optionsBuilder.UseSqlServer("Server=DEV-DIANAD\\MSSQLSERVER2019;Database=Fintech;User ID=sa;Password=Bizagi2018;trustServerCertificate=true ");
            }
        }*/

        public virtual DbSet<CreditEvaluation> CreditEvaluations { get; set; } = null!;
        public virtual DbSet<CreditRequest> CreditRequests { get; set; } = null!;
        public virtual DbSet<Customer> Customers { get; set; } = null!;
        public virtual DbSet<IdentityType> IdentityTypes { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CreditEvaluation>(entity =>
            {
                entity.ToTable("CreditEvaluation");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Comments).HasMaxLength(200);
            });

            modelBuilder.Entity<CreditRequest>(entity =>
            {
                entity.ToTable("CreditRequest");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Comments).HasMaxLength(400);

                entity.Property(e => e.Imagen).HasMaxLength(200);
            });

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.ToTable("Customer");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.BirthDate).HasColumnType("date");

                entity.Property(e => e.CellPhoneNumber).HasMaxLength(50);

                entity.Property(e => e.Email).HasMaxLength(50);

                entity.Property(e => e.FullName).HasMaxLength(50);

                entity.Property(e => e.IdentityNumber).HasMaxLength(50);
            });

            modelBuilder.Entity<IdentityType>(entity =>
            {
                entity.ToTable("IdentityType");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Name).HasMaxLength(50);
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Password).HasMaxLength(50);

                entity.Property(e => e.UserName).HasMaxLength(50);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
