
using IsRotasiProje.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace IsRotasiProje.Models
{
    public class AppDbContext : IdentityDbContext<AppUser,IdentityRole,string>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        public DbSet<Basvuru> Basvurus { get; set; }

        public DbSet<CalismaSekli> CalismaSeklis { get; set; }

        public DbSet<Ilan> Ilans { get; set; }

        public DbSet<Iletisim> Iletisims { get; set; }

        public DbSet<Kategori> Kategoris { get; set; }

        public DbSet<MaasAraligi> MaasAraligis { get; set; }

        public DbSet<Pozisyon> Pozisyons { get; set; }


        public DbSet<Sehir> Sehirs { get; set; }


        public DbSet<Bulten> Bulten { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Basvuru>(entity =>
            {
                entity.ToTable("Basvuru");

                entity.Property(e => e.BasvuruId).HasColumnName("BasvuruID");
                entity.Property(e => e.IlanId).HasColumnName("IlanID");
                entity.Property(e => e.Tarih).HasColumnType("date");
                entity.Property(e => e.UserId)
                    .HasMaxLength(450)
                    .HasColumnName("UserID");

                entity.HasOne(d => d.Ilan).WithMany(p => p.Basvurus)
                    .HasForeignKey(d => d.IlanId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Basvuru_Ilan");

                entity.HasOne(d => d.User).WithMany(p => p.Basvurus)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_Basvuru_Users");
            });

            modelBuilder.Entity<CalismaSekli>(entity =>
            {
                entity.ToTable("CalismaSekli");

                entity.Property(e => e.CalismaSekliId).HasColumnName("CalismaSekliID");
                entity.Property(e => e.CalismaSekliIsim).HasMaxLength(20);
            });
            modelBuilder.Entity<Bulten>(entity =>
            {
                entity.ToTable("Bulten");

                entity.Property(e => e.Id).HasColumnName("Id");
                entity.Property(e => e.Email).HasMaxLength(50);
            });

            modelBuilder.Entity<Ilan>(entity =>
            {
                entity.HasKey(e => e.IlanId).HasName("PK_Table_1");

                entity.ToTable("Ilan");

                entity.Property(e => e.IlanId).HasColumnName("IlanID");
                entity.Property(e => e.CalismaSekliId).HasColumnName("CalismaSekliID");
                entity.Property(e => e.KategoriId).HasColumnName("KategoriID");
                entity.Property(e => e.MaasAraligiId).HasColumnName("MaasAraligiID");
                entity.Property(e => e.PozisyonId).HasColumnName("PozisyonID");
                entity.Property(e => e.SehirId).HasColumnName("SehirID");
                entity.Property(e=> e.IlanAd).HasMaxLength(40);
                entity.Property(e => e.UserId)
                    .HasMaxLength(450)
                    .HasColumnName("UserID");

                entity.HasOne(d => d.CalismaSekli).WithMany(p => p.Ilans)
                    .HasForeignKey(d => d.CalismaSekliId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Ilan_CalismaSekli");

                entity.HasOne(d => d.Kategori).WithMany(p => p.Ilans)
                    .HasForeignKey(d => d.KategoriId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Ilan_Kategori");

                entity.HasOne(d => d.MaasAraligi).WithMany(p => p.Ilans)
                    .HasForeignKey(d => d.MaasAraligiId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Ilan_MaasAraligi");

                entity.HasOne(d => d.Pozisyon).WithMany(p => p.Ilans)
                    .HasForeignKey(d => d.PozisyonId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Ilan_Pozisyon");

                entity.HasOne(d => d.Sehir).WithMany(p => p.Ilans)
                    .HasForeignKey(d => d.SehirId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Ilan_Sehir");

                entity.HasOne(d => d.User).WithMany(p => p.Ilans)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Ilan_Users");
            });

            modelBuilder.Entity<Iletisim>(entity =>
            {
                entity.ToTable("Iletisim");

                entity.Property(e => e.IletisimId).HasColumnName("IletisimID");
                entity.Property(e => e.Email).HasMaxLength(50);
            });

            modelBuilder.Entity<Kategori>(entity =>
            {
                entity.ToTable("Kategori");

                entity.Property(e => e.KategoriId).HasColumnName("KategoriID");
                entity.Property(e => e.KategoriIsim).HasMaxLength(50);
            });

            modelBuilder.Entity<MaasAraligi>(entity =>
            {
                entity.ToTable("MaasAraligi");

                entity.Property(e => e.MaasAraligiId).HasColumnName("MaasAraligiID");
                entity.Property(e => e.Aralik).HasMaxLength(20);
            });

            modelBuilder.Entity<Pozisyon>(entity =>
            {
                entity.ToTable("Pozisyon");

                entity.Property(e => e.PozisyonId).HasColumnName("PozisyonID");
                entity.Property(e => e.PozisyonIsim).HasMaxLength(40);
            });


            modelBuilder.Entity<Sehir>(entity =>
            {
                entity.ToTable("Sehir");

                entity.Property(e => e.SehirId).HasColumnName("SehirID");
                entity.Property(e => e.SehirIsim).HasMaxLength(30);
            });


            base.OnModelCreating(modelBuilder);
        }
    }
}
