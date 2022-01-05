using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace GameMarktDBF2.DAL.Models
{
    public partial class GameMarktContext : DbContext
    {
        public GameMarktContext()
        {
        }

        public GameMarktContext(DbContextOptions<GameMarktContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Kategori> Kategori { get; set; }
        public virtual DbSet<Musteri> Musteri { get; set; }
        public virtual DbSet<Rol> Rol { get; set; }
        public virtual DbSet<Stok> Stok { get; set; }
        public virtual DbSet<Urun> Urun { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=DESKTOP-HFK47PU\\SQLEXPRESS;Initial Catalog=GameMarkt;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Kategori>(entity =>
            {
                entity.HasIndex(e => e.KategoriAd)
                    .HasName("UQ__Kategori__17820D79435582C1")
                    .IsUnique();

                entity.Property(e => e.KategoriAd).HasMaxLength(40);
            });

            modelBuilder.Entity<Musteri>(entity =>
            {
                entity.HasIndex(e => e.EmailId)
                    .HasName("UQ__Musteri__7ED91ACEAE37DB84")
                    .IsUnique();

                entity.HasIndex(e => e.Soyadi)
                    .HasName("UQ__Musteri__9399E83F507B637D")
                    .IsUnique();

                entity.Property(e => e.Adi)
                    .IsRequired()
                    .HasMaxLength(40);

                entity.Property(e => e.EmailId)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(24);

                entity.Property(e => e.RolId).HasDefaultValueSql("((1))");

                entity.Property(e => e.Soyadi)
                    .IsRequired()
                    .HasMaxLength(40);

                entity.HasOne(d => d.Rol)
                    .WithMany(p => p.Musteri)
                    .HasForeignKey(d => d.RolId)
                    .HasConstraintName("FK_Musteri_Rol");
            });

            modelBuilder.Entity<Rol>(entity =>
            {
                entity.HasIndex(e => e.RolAdi)
                    .HasName("UQ__Rol__85F2635DB2C83C37")
                    .IsUnique();

                entity.Property(e => e.RolAdi).HasMaxLength(40);
            });

            modelBuilder.Entity<Stok>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.HasOne(d => d.Urun)
                    .WithMany(p => p.Stok)
                    .HasForeignKey(d => d.UrunId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Stok_Urun");
            });

            modelBuilder.Entity<Urun>(entity =>
            {
                entity.HasIndex(e => e.UrunAd)
                    .HasName("UQ__Urun__623DF7608074BE2F")
                    .IsUnique();

                entity.Property(e => e.Fiyat).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.UrunAd).HasMaxLength(100);

                entity.HasOne(d => d.Kategori)
                    .WithMany(p => p.Urun)
                    .HasForeignKey(d => d.KategoriId)
                    .HasConstraintName("FK__Urun__KategoriId__3A81B327");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
