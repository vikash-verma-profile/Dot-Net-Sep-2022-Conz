using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace SupplierApp.Models
{
    public partial class CustomerDBContext : DbContext
    {
        public CustomerDBContext()
        {
        }

        public CustomerDBContext(DbContextOptions<CustomerDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Supplier> Suppliers { get; set; }
        public virtual DbSet<TblDummyDatum> TblDummyData { get; set; }
        public virtual DbSet<TblImage> TblImages { get; set; }
        public virtual DbSet<TblLogin> TblLogins { get; set; }
        public virtual DbSet<TblOrder> TblOrders { get; set; }
        public virtual DbSet<TblProduct> TblProducts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.Property(e => e.CustomerCode).HasMaxLength(200);

                entity.Property(e => e.CustomerName).HasMaxLength(200);
            });

            modelBuilder.Entity<Supplier>(entity =>
            {
                entity.Property(e => e.SupplierCode).HasMaxLength(200);

                entity.Property(e => e.SupplierName).HasMaxLength(200);
            });

            modelBuilder.Entity<TblDummyDatum>(entity =>
            {
                entity.ToTable("tblDummyData");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.TextData).HasMaxLength(50);
            });

            modelBuilder.Entity<TblImage>(entity =>
            {
                entity.ToTable("tblImages");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.ImageUrl).HasMaxLength(200);
            });

            modelBuilder.Entity<TblLogin>(entity =>
            {
                entity.ToTable("tblLogin");

                entity.Property(e => e.Password).HasMaxLength(200);

                entity.Property(e => e.UserName).HasMaxLength(200);
            });

            modelBuilder.Entity<TblOrder>(entity =>
            {
                entity.ToTable("tblOrder");

                entity.Property(e => e.OrderNumber).HasMaxLength(50);

                entity.Property(e => e.ProductColor).HasMaxLength(50);

                entity.Property(e => e.ProductName).HasMaxLength(50);

                entity.Property(e => e.ProductSize).HasMaxLength(50);
            });

            modelBuilder.Entity<TblProduct>(entity =>
            {
                entity.ToTable("tblProduct");

                entity.Property(e => e.ProductName).HasMaxLength(200);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
