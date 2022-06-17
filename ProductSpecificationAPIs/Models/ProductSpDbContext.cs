using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ProductCodeOldAPIs.Models
{
    public partial class ProductSpDbContext : DbContext
    {
        public virtual DbSet<ProductSpecification> ProductSpecifications { get; set; } = null!;
        public virtual DbSet<ProductSpecificationTest> ProductSpecificationTests { get; set; } = null!;
        public ProductSpDbContext(DbContextOptions<ProductSpDbContext> options) : base(options) { }
        public ProductSpDbContext(string connectionString)
            : base(GetOptions(connectionString))
        {

        }
        private static DbContextOptions GetOptions(string connectionString)
        {
            return SqlServerDbContextOptionsExtensions.UseSqlServer(new DbContextOptionsBuilder(), connectionString).Options;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProductSpecification>(entity =>
            {
                entity.ToTable("Product_Specification");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Code).HasMaxLength(100);

                entity.Property(e => e.CupBox).HasColumnName("Cup_Box");

                entity.Property(e => e.CupCon).HasColumnName("Cup_Con");

                entity.Property(e => e.CupPallet).HasColumnName("Cup_Pallet");

                entity.Property(e => e.CupStack).HasColumnName("Cup_Stack");

                entity.Property(e => e.Name).HasMaxLength(200);

                entity.Property(e => e.PalletizerPattern)
                    .HasMaxLength(50)
                    .HasColumnName("Palletizer_Pattern");

                entity.Property(e => e.SapCode)
                    .HasMaxLength(50)
                    .HasColumnName("SAP_Code");

                entity.Property(e => e.StackBox).HasColumnName("Stack_Box");

                entity.Property(e => e.UpdateDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<ProductSpecificationTest>(entity =>
            {
                entity.ToTable("Product_Specification_Test");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Code).HasMaxLength(100);

                entity.Property(e => e.CupBox).HasColumnName("Cup_Box");

                entity.Property(e => e.CupCon).HasColumnName("Cup_Con");

                entity.Property(e => e.CupPallet).HasColumnName("Cup_Pallet");

                entity.Property(e => e.CupStack).HasColumnName("Cup_Stack");

                entity.Property(e => e.Name).HasMaxLength(200);

                entity.Property(e => e.PalletizerPattern)
                    .HasMaxLength(50)
                    .HasColumnName("Palletizer_Pattern");

                entity.Property(e => e.SapCode)
                    .HasMaxLength(50)
                    .HasColumnName("SAP_Code");

                entity.Property(e => e.StackBox).HasColumnName("Stack_Box");

                entity.Property(e => e.UpdateDate).HasColumnType("datetime");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
