using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace Catalog.Models
{
    public partial class CatalogDBContext : DbContext
    {
        public CatalogDBContext()
        {
        }

        public CatalogDBContext(DbContextOptions<CatalogDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<TblProduct> TblProducts { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Category>(entity =>
            {
                entity.ToTable("Category");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<TblProduct>(entity =>
            {
                entity.ToTable("tblProduct");

                entity.Property(e => e.ProductDescription).HasMaxLength(100);

                entity.Property(e => e.ProductId).HasMaxLength(50);

                entity.Property(e => e.ProductName).HasMaxLength(50);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
