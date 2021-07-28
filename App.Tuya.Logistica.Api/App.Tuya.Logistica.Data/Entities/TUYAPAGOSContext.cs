using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace App.Tuya.Logistica.Data.Entities
{
    public partial class TUYAPAGOSContext : DbContext
    {
        public TUYAPAGOSContext()
        {
        }

        public TUYAPAGOSContext(DbContextOptions<TUYAPAGOSContext> options)
            : base(options)
        {
        }

        public virtual DbSet<TblClientInfo> TblClientInfos { get; set; }
        public virtual DbSet<TblDetail> TblDetails { get; set; }
        public virtual DbSet<TblOrder> TblOrders { get; set; }
        public virtual DbSet<TblProduct> TblProducts { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=LAPTOP-YULS;Initial Catalog=TUYAPAGOS;Integrated Security=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<TblClientInfo>(entity =>
            {
                entity.HasKey(e => e.ClientInfoId);

                entity.ToTable("tblClientInfo");

                entity.Property(e => e.ClientInfoId).ValueGeneratedNever();

                entity.Property(e => e.Adress)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.ClientName)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.DocumentNumber)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Email).HasMaxLength(200);

                entity.Property(e => e.Phone)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.PostalCode).HasMaxLength(50);
            });

            modelBuilder.Entity<TblDetail>(entity =>
            {
                entity.HasKey(e => e.DetailId);

                entity.ToTable("tblDetail");

                entity.Property(e => e.DetailId).ValueGeneratedNever();

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.TblDetails)
                    .HasForeignKey(d => d.OrderId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblDetail_tblOrder");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.TblDetails)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblDetail_tblProduct");
            });

            modelBuilder.Entity<TblOrder>(entity =>
            {
                entity.HasKey(e => e.OrderId);

                entity.ToTable("tblOrder");

                entity.Property(e => e.OrderId).ValueGeneratedNever();

                entity.Property(e => e.Date).HasColumnType("date");

                entity.Property(e => e.OrderCode)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.HasOne(d => d.ClientInfo)
                    .WithMany(p => p.TblOrders)
                    .HasForeignKey(d => d.ClientInfoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblOrder_tblClientInfo");
            });

            modelBuilder.Entity<TblProduct>(entity =>
            {
                entity.HasKey(e => e.ProductId);

                entity.ToTable("tblProduct");

                entity.Property(e => e.ProductId).ValueGeneratedNever();

                entity.Property(e => e.ProductCode)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.ProductName)
                    .IsRequired()
                    .HasMaxLength(200);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
