﻿// <auto-generated />
using System;
using IsRotasiProje.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace IsRotasiProje.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20230803085218_initial")]
    partial class initial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("IsRotasiProje.Models.AppUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("Ad")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Bilgisayar")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Deneyim")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("DogumTarihi")
                        .HasColumnType("datetime2");

                    b.Property<string>("Egitim")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("Hobi")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Image")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("Ozet")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Tarih")
                        .HasColumnType("datetime2");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("Website")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);
                });

            modelBuilder.Entity("IsRotasiProje.Models.Basvuru", b =>
                {
                    b.Property<int>("BasvuruId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("BasvuruID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("BasvuruId"));

                    b.Property<int>("IlanId")
                        .HasColumnType("int")
                        .HasColumnName("IlanID");

                    b.Property<DateTime>("Tarih")
                        .HasColumnType("date");

                    b.Property<string>("UserId")
                        .HasMaxLength(450)
                        .HasColumnType("nvarchar(450)")
                        .HasColumnName("UserID");

                    b.HasKey("BasvuruId");

                    b.HasIndex("IlanId");

                    b.HasIndex("UserId");

                    b.ToTable("Basvuru", (string)null);
                });

            modelBuilder.Entity("IsRotasiProje.Models.Bulten", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Bulten", (string)null);
                });

            modelBuilder.Entity("IsRotasiProje.Models.CalismaSekli", b =>
                {
                    b.Property<int>("CalismaSekliId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("CalismaSekliID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CalismaSekliId"));

                    b.Property<string>("CalismaSekliIsim")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("CalismaSekliId");

                    b.ToTable("CalismaSekli", (string)null);
                });

            modelBuilder.Entity("IsRotasiProje.Models.Ilan", b =>
                {
                    b.Property<int>("IlanId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("IlanID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IlanId"));

                    b.Property<string>("AdayGereklilik")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("CalismaSekliId")
                        .HasColumnType("int")
                        .HasColumnName("CalismaSekliID");

                    b.Property<string>("IlanAd")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)");

                    b.Property<string>("IsTanimi")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("KategoriId")
                        .HasColumnType("int")
                        .HasColumnName("KategoriID");

                    b.Property<int>("MaasAraligiId")
                        .HasColumnType("int")
                        .HasColumnName("MaasAraligiID");

                    b.Property<int>("PozisyonId")
                        .HasColumnType("int")
                        .HasColumnName("PozisyonID");

                    b.Property<int>("SehirId")
                        .HasColumnType("int")
                        .HasColumnName("SehirID");

                    b.Property<DateTime>("Tarih")
                        .HasColumnType("datetime2");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasMaxLength(450)
                        .HasColumnType("nvarchar(450)")
                        .HasColumnName("UserID");

                    b.HasKey("IlanId")
                        .HasName("PK_Table_1");

                    b.HasIndex("CalismaSekliId");

                    b.HasIndex("KategoriId");

                    b.HasIndex("MaasAraligiId");

                    b.HasIndex("PozisyonId");

                    b.HasIndex("SehirId");

                    b.HasIndex("UserId");

                    b.ToTable("Ilan", (string)null);
                });

            modelBuilder.Entity("IsRotasiProje.Models.Iletisim", b =>
                {
                    b.Property<int>("IletisimId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("IletisimID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IletisimId"));

                    b.Property<string>("AdSoyad")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Mesaj")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Tarih")
                        .HasColumnType("datetime2");

                    b.HasKey("IletisimId");

                    b.ToTable("Iletisim", (string)null);
                });

            modelBuilder.Entity("IsRotasiProje.Models.Kategori", b =>
                {
                    b.Property<int>("KategoriId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("KategoriID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("KategoriId"));

                    b.Property<string>("KategoriIsim")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("KategoriId");

                    b.ToTable("Kategori", (string)null);
                });

            modelBuilder.Entity("IsRotasiProje.Models.MaasAraligi", b =>
                {
                    b.Property<int>("MaasAraligiId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("MaasAraligiID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MaasAraligiId"));

                    b.Property<string>("Aralik")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("MaasAraligiId");

                    b.ToTable("MaasAraligi", (string)null);
                });

            modelBuilder.Entity("IsRotasiProje.Models.Pozisyon", b =>
                {
                    b.Property<int>("PozisyonId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("PozisyonID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PozisyonId"));

                    b.Property<string>("PozisyonIsim")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)");

                    b.HasKey("PozisyonId");

                    b.ToTable("Pozisyon", (string)null);
                });

            modelBuilder.Entity("IsRotasiProje.Models.Sehir", b =>
                {
                    b.Property<int>("SehirId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("SehirID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SehirId"));

                    b.Property<string>("SehirIsim")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.HasKey("SehirId");

                    b.ToTable("Sehir", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("IsRotasiProje.Models.Basvuru", b =>
                {
                    b.HasOne("IsRotasiProje.Models.Ilan", "Ilan")
                        .WithMany("Basvurus")
                        .HasForeignKey("IlanId")
                        .IsRequired()
                        .HasConstraintName("FK_Basvuru_Ilan");

                    b.HasOne("IsRotasiProje.Models.AppUser", "User")
                        .WithMany("Basvurus")
                        .HasForeignKey("UserId")
                        .HasConstraintName("FK_Basvuru_Users");

                    b.Navigation("Ilan");

                    b.Navigation("User");
                });

            modelBuilder.Entity("IsRotasiProje.Models.Ilan", b =>
                {
                    b.HasOne("IsRotasiProje.Models.CalismaSekli", "CalismaSekli")
                        .WithMany("Ilans")
                        .HasForeignKey("CalismaSekliId")
                        .IsRequired()
                        .HasConstraintName("FK_Ilan_CalismaSekli");

                    b.HasOne("IsRotasiProje.Models.Kategori", "Kategori")
                        .WithMany("Ilans")
                        .HasForeignKey("KategoriId")
                        .IsRequired()
                        .HasConstraintName("FK_Ilan_Kategori");

                    b.HasOne("IsRotasiProje.Models.MaasAraligi", "MaasAraligi")
                        .WithMany("Ilans")
                        .HasForeignKey("MaasAraligiId")
                        .IsRequired()
                        .HasConstraintName("FK_Ilan_MaasAraligi");

                    b.HasOne("IsRotasiProje.Models.Pozisyon", "Pozisyon")
                        .WithMany("Ilans")
                        .HasForeignKey("PozisyonId")
                        .IsRequired()
                        .HasConstraintName("FK_Ilan_Pozisyon");

                    b.HasOne("IsRotasiProje.Models.Sehir", "Sehir")
                        .WithMany("Ilans")
                        .HasForeignKey("SehirId")
                        .IsRequired()
                        .HasConstraintName("FK_Ilan_Sehir");

                    b.HasOne("IsRotasiProje.Models.AppUser", "User")
                        .WithMany("Ilans")
                        .HasForeignKey("UserId")
                        .IsRequired()
                        .HasConstraintName("FK_Ilan_Users");

                    b.Navigation("CalismaSekli");

                    b.Navigation("Kategori");

                    b.Navigation("MaasAraligi");

                    b.Navigation("Pozisyon");

                    b.Navigation("Sehir");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("IsRotasiProje.Models.AppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("IsRotasiProje.Models.AppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("IsRotasiProje.Models.AppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("IsRotasiProje.Models.AppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("IsRotasiProje.Models.AppUser", b =>
                {
                    b.Navigation("Basvurus");

                    b.Navigation("Ilans");
                });

            modelBuilder.Entity("IsRotasiProje.Models.CalismaSekli", b =>
                {
                    b.Navigation("Ilans");
                });

            modelBuilder.Entity("IsRotasiProje.Models.Ilan", b =>
                {
                    b.Navigation("Basvurus");
                });

            modelBuilder.Entity("IsRotasiProje.Models.Kategori", b =>
                {
                    b.Navigation("Ilans");
                });

            modelBuilder.Entity("IsRotasiProje.Models.MaasAraligi", b =>
                {
                    b.Navigation("Ilans");
                });

            modelBuilder.Entity("IsRotasiProje.Models.Pozisyon", b =>
                {
                    b.Navigation("Ilans");
                });

            modelBuilder.Entity("IsRotasiProje.Models.Sehir", b =>
                {
                    b.Navigation("Ilans");
                });
#pragma warning restore 612, 618
        }
    }
}
