﻿// <auto-generated />
using System;
using KuaforWebSitesi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace KuaforWebSitesi.Migrations
{
    [DbContext(typeof(KuaforDBContext))]
    [Migration("20241212153937_virtual")]
    partial class @virtual
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("KuaforWebSitesi.Models.Calisan", b =>
                {
                    b.Property<int>("CalisanID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CalisanID"));

                    b.Property<string>("CalisanAd")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CalisanMail")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CalisanSifre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CalisanSoyad")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CalisanTelefon")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CalisanID");

                    b.ToTable("Calisanlar");
                });

            modelBuilder.Entity("KuaforWebSitesi.Models.CalisanGun", b =>
                {
                    b.Property<int>("CalisanGunID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CalisanGunID"));

                    b.Property<int>("CalisanID")
                        .HasColumnType("int");

                    b.Property<int>("GunID")
                        .HasColumnType("int");

                    b.HasKey("CalisanGunID");

                    b.HasIndex("CalisanID");

                    b.HasIndex("GunID");

                    b.ToTable("CalisanGunler");
                });

            modelBuilder.Entity("KuaforWebSitesi.Models.CalisanHizmetler", b =>
                {
                    b.Property<int>("CalisanHizmetID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CalisanHizmetID"));

                    b.Property<int>("CalisanID")
                        .HasColumnType("int");

                    b.Property<int>("HizmetID")
                        .HasColumnType("int");

                    b.HasKey("CalisanHizmetID");

                    b.HasIndex("CalisanID");

                    b.HasIndex("HizmetID");

                    b.ToTable("CalisanHizmetler");
                });

            modelBuilder.Entity("KuaforWebSitesi.Models.Gunler", b =>
                {
                    b.Property<int>("GunID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("GunID"));

                    b.Property<string>("GunAdi")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("GunID");

                    b.ToTable("Gunler");

                    b.HasData(
                        new
                        {
                            GunID = 1,
                            GunAdi = "Pazartesi"
                        },
                        new
                        {
                            GunID = 2,
                            GunAdi = "Salı"
                        },
                        new
                        {
                            GunID = 3,
                            GunAdi = "Çarşamba"
                        },
                        new
                        {
                            GunID = 4,
                            GunAdi = "Perşembe"
                        },
                        new
                        {
                            GunID = 5,
                            GunAdi = "Cuma"
                        },
                        new
                        {
                            GunID = 6,
                            GunAdi = "Cumartesi"
                        },
                        new
                        {
                            GunID = 7,
                            GunAdi = "Pazar"
                        });
                });

            modelBuilder.Entity("KuaforWebSitesi.Models.HizmetKategori", b =>
                {
                    b.Property<int>("HizmetKategoriID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("HizmetKategoriID"));

                    b.Property<string>("KategoriAdi")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("HizmetKategoriID");

                    b.ToTable("HizmetKategoriler");
                });

            modelBuilder.Entity("KuaforWebSitesi.Models.Hizmetler", b =>
                {
                    b.Property<int>("HizmetID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("HizmetID"));

                    b.Property<decimal>("Fiyat")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("HizmetAdi")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("HizmetKategoriID")
                        .HasColumnType("int");

                    b.Property<TimeSpan>("Sure")
                        .HasColumnType("time");

                    b.HasKey("HizmetID");

                    b.HasIndex("HizmetKategoriID");

                    b.ToTable("Hizmetler");
                });

            modelBuilder.Entity("KuaforWebSitesi.Models.Musteri", b =>
                {
                    b.Property<int>("MusteriID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MusteriID"));

                    b.Property<string>("MusteriAd")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("MusteriMail")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MusteriSifre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MusteriSoyad")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MusteriTelefon")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("MusteriID");

                    b.ToTable("Musteriler");
                });

            modelBuilder.Entity("KuaforWebSitesi.Models.Randevu", b =>
                {
                    b.Property<int>("RandevuID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("RandevuID"));

                    b.Property<int?>("CalisanID")
                        .HasColumnType("int");

                    b.Property<string>("Durum")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("HizmetID")
                        .HasColumnType("int");

                    b.Property<int?>("MusteriID")
                        .HasColumnType("int");

                    b.Property<TimeSpan>("Saat")
                        .HasColumnType("time");

                    b.Property<DateTime>("Tarih")
                        .HasColumnType("datetime2");

                    b.HasKey("RandevuID");

                    b.HasIndex("CalisanID");

                    b.HasIndex("HizmetID");

                    b.HasIndex("MusteriID");

                    b.ToTable("Randevular");
                });

            modelBuilder.Entity("KuaforWebSitesi.Models.CalisanGun", b =>
                {
                    b.HasOne("KuaforWebSitesi.Models.Calisan", "Calisanlar")
                        .WithMany("CalisanGunler")
                        .HasForeignKey("CalisanID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("KuaforWebSitesi.Models.Gunler", "Gunler")
                        .WithMany("CalisanGunler")
                        .HasForeignKey("GunID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Calisanlar");

                    b.Navigation("Gunler");
                });

            modelBuilder.Entity("KuaforWebSitesi.Models.CalisanHizmetler", b =>
                {
                    b.HasOne("KuaforWebSitesi.Models.Calisan", "Calisan")
                        .WithMany("CalisanHizmetler")
                        .HasForeignKey("CalisanID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("KuaforWebSitesi.Models.Hizmetler", "Hizmet")
                        .WithMany("CalisanHizmetler")
                        .HasForeignKey("HizmetID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Calisan");

                    b.Navigation("Hizmet");
                });

            modelBuilder.Entity("KuaforWebSitesi.Models.Hizmetler", b =>
                {
                    b.HasOne("KuaforWebSitesi.Models.HizmetKategori", "HizmetKategori")
                        .WithMany("Hizmetler")
                        .HasForeignKey("HizmetKategoriID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("HizmetKategori");
                });

            modelBuilder.Entity("KuaforWebSitesi.Models.Randevu", b =>
                {
                    b.HasOne("KuaforWebSitesi.Models.Calisan", "Calisan")
                        .WithMany("Randevular")
                        .HasForeignKey("CalisanID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("KuaforWebSitesi.Models.Hizmetler", "Hizmet")
                        .WithMany("Randevular")
                        .HasForeignKey("HizmetID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("KuaforWebSitesi.Models.Musteri", "Musteri")
                        .WithMany("Randevular")
                        .HasForeignKey("MusteriID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.Navigation("Calisan");

                    b.Navigation("Hizmet");

                    b.Navigation("Musteri");
                });

            modelBuilder.Entity("KuaforWebSitesi.Models.Calisan", b =>
                {
                    b.Navigation("CalisanGunler");

                    b.Navigation("CalisanHizmetler");

                    b.Navigation("Randevular");
                });

            modelBuilder.Entity("KuaforWebSitesi.Models.Gunler", b =>
                {
                    b.Navigation("CalisanGunler");
                });

            modelBuilder.Entity("KuaforWebSitesi.Models.HizmetKategori", b =>
                {
                    b.Navigation("Hizmetler");
                });

            modelBuilder.Entity("KuaforWebSitesi.Models.Hizmetler", b =>
                {
                    b.Navigation("CalisanHizmetler");

                    b.Navigation("Randevular");
                });

            modelBuilder.Entity("KuaforWebSitesi.Models.Musteri", b =>
                {
                    b.Navigation("Randevular");
                });
#pragma warning restore 612, 618
        }
    }
}