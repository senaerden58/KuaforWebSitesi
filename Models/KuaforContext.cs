using System;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using System.Runtime.Intrinsics.Arm;
using KuaforWebSitesi.Migrations;


namespace KuaforWebSitesi.Models
{
    public class KuaforDBContext : DbContext
    {
        public KuaforDBContext(DbContextOptions<KuaforDBContext> options) : base(options)
        {
        }

        public DbSet<Musteri> Musteriler { get; set; }
        public DbSet<Calisan> Calisanlar { get; set; }
        public DbSet<Hizmetler> Hizmetler { get; set; }
        public DbSet<Randevu> Randevular { get; set; }
        public DbSet<Admin> Admin { get; set; }
        public DbSet<CalisanHizmetler> CalisanHizmetler { get; set; }
        public DbSet<Gunler> Gunler { get; set; }
        public DbSet<HizmetKategori> HizmetKategoriler { get; set; }
        public DbSet<CalisanGun> CalisanGunler { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Hizmetler>()
                .Property(h => h.Fiyat)
                .HasColumnType("decimal(18,2)"); // Burada (18,2) hassasiyeti ve ölçeği belirtir.

            // Çalışan ve Günler arasındaki ilişkiyi belirtiriz
            modelBuilder.Entity<CalisanGun>()
                .HasOne(cg => cg.Calisanlar)
                .WithMany(c => c.CalisanGunler)
                .HasForeignKey(cg => cg.CalisanID);

            modelBuilder.Entity<CalisanGun>()
                .HasOne(cg => cg.Gunler)
                .WithMany(g => g.CalisanGunler)
                .HasForeignKey(cg => cg.GunID);

            modelBuilder.Entity<Hizmetler>()
                 .HasOne(h => h.HizmetKategoriler)   // Hizmetler tablosunun bir HizmetKategori'ye ait olduğunu belirtiyoruz
                 .WithMany(k => k.Hizmetler)     // HizmetKategori tablosunun birden fazla Hizmetler içerebileceğini belirtiyoruz
                 .HasForeignKey(h => h.HizmetKategoriID); // Yabancı anahtar ilişkisini kuruyoruz


            modelBuilder.Entity<CalisanHizmetler>()
                .HasOne(ch => ch.Calisan)
                .WithMany(c => c.CalisanHizmetler)
                .HasForeignKey(ch => ch.CalisanID);

            modelBuilder.Entity<CalisanHizmetler>()
                .HasOne(ch => ch.Hizmet)
                .WithMany(h => h.CalisanHizmetler)
                .HasForeignKey(ch => ch.HizmetID);

            // Randevu ile Musteri arasındaki ilişki
            modelBuilder.Entity<Randevu>()
             .HasOne(r => r.Musteri)     // Randevu, Müşteri'ye bağlı
             .WithMany(m => m.Randevular)
            .HasForeignKey(r => r.MusteriID)
            .OnDelete(DeleteBehavior.Cascade); // Müşteri silindiğinde, ona ait randevular silinsin

            modelBuilder.Entity<Randevu>()
                .HasOne(r => r.Calisan)     // Randevu, Çalışan'a bağlı
                .WithMany(c => c.Randevular)
                .HasForeignKey(r => r.CalisanID)
                .OnDelete(DeleteBehavior.Cascade); // Çalışan silindiğinde, ona ait randevular silinsin

            modelBuilder.Entity<Randevu>()
                .HasOne(r => r.Hizmet)     // Randevu, Hizmet'e bağlı
                .WithMany(h => h.Randevular)
                .HasForeignKey(r => r.HizmetID)
                .OnDelete(DeleteBehavior.Cascade); // Hizmet silindiğinde, ona ait randevular silinsin

            modelBuilder.Entity<Gunler>().HasData(
                     new Gunler { GunID = 1, GunAdi = "Pazartesi" },
                     new Gunler { GunID = 2, GunAdi = "Salı" },
                    new Gunler { GunID = 3, GunAdi = "Çarşamba" },
                    new Gunler { GunID = 4, GunAdi = "Perşembe" },
                    new Gunler { GunID = 5, GunAdi = "Cuma" },
                    new Gunler { GunID = 6, GunAdi = "Cumartesi" },
                    new Gunler { GunID = 7, GunAdi = "Pazar" }
       );


            modelBuilder.Entity<HizmetKategori>().HasData(
new HizmetKategori { HizmetKategoriID = 1, KategoriAdi = "Saç Kesimi" },
new HizmetKategori { HizmetKategoriID = 2, KategoriAdi = "Saç Bakımı" },
new HizmetKategori { HizmetKategoriID = 3, KategoriAdi = "Manikür" },
new HizmetKategori { HizmetKategoriID = 4, KategoriAdi = "Pedikür" },
new HizmetKategori { HizmetKategoriID = 5, KategoriAdi = "Gelin" }
);




            modelBuilder.Entity<Hizmetler>().HasData(
              new Hizmetler { HizmetID = 1, HizmetAdi = "Fön", Sure = TimeSpan.FromHours(1), Fiyat = 400, HizmetKategoriID = 2 },
              new Hizmetler { HizmetID = 2, HizmetAdi = "Maşa", Sure = TimeSpan.FromHours(1), Fiyat = 800, HizmetKategoriID = 2 },
              new Hizmetler { HizmetID = 3, HizmetAdi = "Örgü", Sure = TimeSpan.FromHours(1), Fiyat = 1000, HizmetKategoriID = 2 },
              new Hizmetler { HizmetID = 4, HizmetAdi = "Topuz", Sure = TimeSpan.FromHours(1), Fiyat = 1200, HizmetKategoriID = 2 },
              new Hizmetler { HizmetID = 5, HizmetAdi = "Saç Kesim", Sure = TimeSpan.FromHours(1), Fiyat = 1300, HizmetKategoriID = 2 },
              new Hizmetler { HizmetID = 6, HizmetAdi = "Cila", Sure = TimeSpan.FromMinutes(45), Fiyat = 2500, HizmetKategoriID = 1 },
              new Hizmetler { HizmetID = 7, HizmetAdi = "Dip Boya", Sure = TimeSpan.FromHours(1), Fiyat = 1250, HizmetKategoriID = 1 },
              new Hizmetler { HizmetID = 8, HizmetAdi = "Transparan Boya", Sure = TimeSpan.FromHours(1), Fiyat = 1750, HizmetKategoriID = 1 },
              new Hizmetler { HizmetID = 9, HizmetAdi = "Bütün Boya", Sure = TimeSpan.FromHours(2), Fiyat = 2500, HizmetKategoriID = 1 },
              new Hizmetler { HizmetID = 10, HizmetAdi = "Brushlight", Sure = TimeSpan.FromHours(3), Fiyat = 5500, HizmetKategoriID = 1 },
              new Hizmetler { HizmetID = 11, HizmetAdi = "Highlight", Sure = TimeSpan.FromHours(5), Fiyat = 6000, HizmetKategoriID = 1 },
              new Hizmetler { HizmetID = 12, HizmetAdi = "Röfle", Sure = TimeSpan.FromHours(5), Fiyat = 8000, HizmetKategoriID = 1 },
              new Hizmetler { HizmetID = 13, HizmetAdi = "Sakinleştirici Bakım", Sure = TimeSpan.FromMinutes(90), Fiyat = 4000, HizmetKategoriID = 1 },
              new Hizmetler { HizmetID = 14, HizmetAdi = "Düzleştirici Bakım", Sure = TimeSpan.FromMinutes(150), Fiyat = 6000, HizmetKategoriID = 1 },
              new Hizmetler { HizmetID = 15, HizmetAdi = "Gelin Saçı", Sure = TimeSpan.FromHours(3), Fiyat = 6000, HizmetKategoriID = 5 },
              new Hizmetler { HizmetID = 16, HizmetAdi = "Gelin Makyajı", Sure = TimeSpan.FromMinutes(90), Fiyat = 6000, HizmetKategoriID = 5 },
              new Hizmetler { HizmetID = 17, HizmetAdi = "Manikür", Sure = TimeSpan.FromMinutes(45), Fiyat = 750, HizmetKategoriID = 3 },
              new Hizmetler { HizmetID = 18, HizmetAdi = "Pedikür", Sure = TimeSpan.FromMinutes(45), Fiyat = 750, HizmetKategoriID = 3 },
              new Hizmetler { HizmetID = 19, HizmetAdi = "El Kalıcı Oje", Sure = TimeSpan.FromMinutes(45), Fiyat = 550, HizmetKategoriID = 3 },
              new Hizmetler { HizmetID = 20, HizmetAdi = "Ayak Kalıcı Oje", Sure = TimeSpan.FromMinutes(45), Fiyat = 750, HizmetKategoriID = 3 },
              new Hizmetler { HizmetID = 21, HizmetAdi = "Profesyonel Cilt Bakımı", Sure = TimeSpan.FromMinutes(90), Fiyat = 2500, HizmetKategoriID = 4 },
              new Hizmetler { HizmetID = 22, HizmetAdi = "Kaş Alımı", Sure = TimeSpan.FromMinutes(20), Fiyat = 400, HizmetKategoriID = 4 },
              new Hizmetler { HizmetID = 23, HizmetAdi = "Kirpik Lifting", Sure = TimeSpan.FromMinutes(45), Fiyat = 1250, HizmetKategoriID = 4 },
              new Hizmetler { HizmetID = 24, HizmetAdi = "Karbon Peeling", Sure = TimeSpan.FromMinutes(45), Fiyat = 1500, HizmetKategoriID = 4 }
          );

            modelBuilder.Entity<Admin>().HasData(
                new Admin { AdminID = 1, AdminMail = "b211210041@sakarya.edu.tr", AdminSifre = "sau" }
                );


            modelBuilder.Entity<Calisan>().HasData(
                new Calisan
                {
                    CalisanID = 1,
                    CalisanAd = "Dilan",
                    CalisanSoyad = "Kaya",
                    CalisanMail = "dilan.kaya@shineLab.com",
                    CalisanTelefon = "05395456751",
                    CalisanSifre = "Dilan123"
                },
                 new Calisan
                 {
                     CalisanID = 2,
                     CalisanAd = "Elif",
                     CalisanSoyad = "Yılmaz",
                     CalisanMail = "elif.yilmaz@shineLab.com",
                     CalisanTelefon = "05395456752",
                     CalisanSifre = "Elif123"
                 },

                  new Calisan
                  {
                      CalisanID = 3,
                      CalisanAd = "Şeyma",
                      CalisanSoyad = "Çetin",
                      CalisanMail = "seyma.cetin@shineLab.com",
                      CalisanTelefon = "05395456753",
                      CalisanSifre = "Seyma123"
                  },

                        new Calisan
                        {
                            CalisanID = 4,
                            CalisanAd = "Ece",
                            CalisanSoyad = "Tuncer",
                            CalisanMail = "ece.tuncer@shineLab.com",
                            CalisanTelefon = "05395456754",
                            CalisanSifre = "Ece123"
                        },
                          new Calisan
                          {
                              CalisanID = 5,
                              CalisanAd = "Aslı",
                              CalisanSoyad = "Şahin",
                              CalisanMail = "asli.sahin@shineLab.com",
                              CalisanTelefon = "05395456755",
                              CalisanSifre = "ShineLaB"
                          },
                              new Calisan
                              {
                                  CalisanID = 6,
                                  CalisanAd = "Ceyda",
                                  CalisanSoyad = "Özdemir",
                                  CalisanMail = "ceyda.ozdemir@shineLab.com",
                                  CalisanTelefon = "05395456756",
                                  CalisanSifre = "Ceyda123"
                              },
                                  new Calisan
                                  {
                                      CalisanID = 7,
                                      CalisanAd = "Nisan",
                                      CalisanSoyad = "Kaya",
                                      CalisanMail = "nisan.kaya@shineLab.com",
                                      CalisanTelefon = "05395456757",
                                      CalisanSifre = "Nisan123"
                                  }
                              );


            modelBuilder.Entity<CalisanGun>().HasData(
                new CalisanGun { CalisanGunID =1,  CalisanID =1, GunID =1 },
                new CalisanGun { CalisanGunID = 2, CalisanID =1, GunID =5},
                new CalisanGun { CalisanGunID = 3, CalisanID =2, GunID =2},
                new CalisanGun { CalisanGunID = 4, CalisanID =2, GunID =3},
                new CalisanGun { CalisanGunID = 5, CalisanID =2, GunID =4},
                new CalisanGun { CalisanGunID = 6, CalisanID =2, GunID =5},
                new CalisanGun { CalisanGunID = 7, CalisanID =2, GunID =6},
                new CalisanGun { CalisanGunID = 8, CalisanID =3, GunID =1},
                new CalisanGun { CalisanGunID = 9, CalisanID =3, GunID =3},
                new CalisanGun { CalisanGunID = 10, CalisanID =3, GunID =5},
                new CalisanGun { CalisanGunID = 11, CalisanID =3, GunID =6},
                new CalisanGun { CalisanGunID = 12, CalisanID =4, GunID =1}, 
                new CalisanGun { CalisanGunID = 13, CalisanID =4, GunID =2},
                new CalisanGun { CalisanGunID = 14, CalisanID =4, GunID =5},
                new CalisanGun { CalisanGunID = 15, CalisanID =4, GunID =6},
                new CalisanGun { CalisanGunID = 16, CalisanID =5, GunID =1},
                new CalisanGun { CalisanGunID = 17, CalisanID =5, GunID =5},
                new CalisanGun { CalisanGunID = 18, CalisanID =5, GunID =7},
                new CalisanGun { CalisanGunID = 19, CalisanID =6, GunID =2},
                new CalisanGun { CalisanGunID = 20, CalisanID =6, GunID =3},
                new CalisanGun { CalisanGunID = 21, CalisanID =6, GunID =5},
                new CalisanGun { CalisanGunID = 22, CalisanID =6, GunID =6},
                new CalisanGun { CalisanGunID = 23, CalisanID =6, GunID =7},
                new CalisanGun { CalisanGunID = 24, CalisanID =7, GunID =1},
                new CalisanGun { CalisanGunID = 25, CalisanID =7, GunID =3},
                new CalisanGun { CalisanGunID = 26, CalisanID =7, GunID =4},
                new CalisanGun { CalisanGunID = 27, CalisanID =7, GunID =7}
                );

            modelBuilder.Entity<CalisanHizmetler>().HasData(
                new CalisanHizmetler{CalisanHizmetID = 1, CalisanID = 1,HizmetID = 1},
                new CalisanHizmetler{CalisanHizmetID = 2, CalisanID = 1, HizmetID = 2 },
                new CalisanHizmetler{CalisanHizmetID = 3, CalisanID = 1, HizmetID =3},
                new CalisanHizmetler{CalisanHizmetID=4,  CalisanID=1 ,HizmetID=4},
                new CalisanHizmetler{CalisanHizmetID=5,  CalisanID=1 ,HizmetID=5},
                new CalisanHizmetler{CalisanHizmetID=6,  CalisanID=1 ,HizmetID=6},
                new CalisanHizmetler{CalisanHizmetID=7,  CalisanID=1 ,HizmetID=7},
                new CalisanHizmetler{CalisanHizmetID=8,  CalisanID=1 ,HizmetID=8},
                new CalisanHizmetler{CalisanHizmetID=9,  CalisanID=1 ,HizmetID=9},
                new CalisanHizmetler{CalisanHizmetID=10, CalisanID=1,HizmetID=10},
                new CalisanHizmetler{CalisanHizmetID=11, CalisanID=1,HizmetID=11},
                new CalisanHizmetler{CalisanHizmetID=12, CalisanID=1,HizmetID=12},
                new CalisanHizmetler{CalisanHizmetID=13, CalisanID=1,HizmetID=13},
                new CalisanHizmetler{CalisanHizmetID=14, CalisanID=1,HizmetID=14},
                new CalisanHizmetler{CalisanHizmetID=15, CalisanID=1,HizmetID=15},
                new CalisanHizmetler{CalisanHizmetID=16, CalisanID=1,HizmetID=16},
                new CalisanHizmetler{CalisanHizmetID=17, CalisanID=2,HizmetID=1},
                new CalisanHizmetler{CalisanHizmetID=18, CalisanID=2,HizmetID=2},
                new CalisanHizmetler{CalisanHizmetID=19, CalisanID=2,HizmetID=3},
                new CalisanHizmetler{CalisanHizmetID=20, CalisanID=2,HizmetID=4},
                new CalisanHizmetler{CalisanHizmetID=21, CalisanID=2,HizmetID=5},
                new CalisanHizmetler{CalisanHizmetID=22, CalisanID=2,HizmetID=6},
                new CalisanHizmetler{CalisanHizmetID=23, CalisanID=2,HizmetID=7},
                new CalisanHizmetler{CalisanHizmetID=24, CalisanID=2,HizmetID=8},
                new CalisanHizmetler{CalisanHizmetID=25, CalisanID=2,HizmetID=9},
                new CalisanHizmetler{CalisanHizmetID=26, CalisanID=2,HizmetID=10},
                new CalisanHizmetler{CalisanHizmetID=27, CalisanID=2,HizmetID=11},
                new CalisanHizmetler{CalisanHizmetID=28, CalisanID=2,HizmetID=12},
                new CalisanHizmetler{CalisanHizmetID=29, CalisanID=2,HizmetID=13},
                new CalisanHizmetler{CalisanHizmetID=30, CalisanID=2,HizmetID=14},
                new CalisanHizmetler{CalisanHizmetID=31, CalisanID=2,HizmetID=15},
                new CalisanHizmetler{CalisanHizmetID=32, CalisanID=2,HizmetID=16},
                new CalisanHizmetler{CalisanHizmetID=33, CalisanID=3,HizmetID=1},
                new CalisanHizmetler{CalisanHizmetID=34, CalisanID=3,HizmetID=2},
                new CalisanHizmetler{CalisanHizmetID=35, CalisanID=3,HizmetID=3},
                new CalisanHizmetler{CalisanHizmetID=36, CalisanID=3,HizmetID=4},
                new CalisanHizmetler{CalisanHizmetID=37, CalisanID=3,HizmetID=5},
                new CalisanHizmetler{CalisanHizmetID=38, CalisanID=3,HizmetID=6},
                new CalisanHizmetler{CalisanHizmetID=39, CalisanID=3,HizmetID=7},
                new CalisanHizmetler{CalisanHizmetID=40, CalisanID=3,HizmetID=8},
                new CalisanHizmetler{CalisanHizmetID=41, CalisanID=3,HizmetID=9},
                new CalisanHizmetler{CalisanHizmetID=42, CalisanID=3,HizmetID=10},
                new CalisanHizmetler{CalisanHizmetID=43, CalisanID=3,HizmetID=11},
                new CalisanHizmetler{CalisanHizmetID=44, CalisanID=3,HizmetID=12},
                new CalisanHizmetler{CalisanHizmetID=45, CalisanID=3,HizmetID=13},
                new CalisanHizmetler{CalisanHizmetID=46, CalisanID=3,HizmetID=14},
                new CalisanHizmetler{CalisanHizmetID=47, CalisanID=4,HizmetID=1},
                new CalisanHizmetler{CalisanHizmetID=48, CalisanID=4,HizmetID=2},
                new CalisanHizmetler{CalisanHizmetID=49, CalisanID=4,HizmetID=3},
                new CalisanHizmetler{CalisanHizmetID=50, CalisanID=4,HizmetID=4},
                new CalisanHizmetler{CalisanHizmetID=51, CalisanID=4,HizmetID=5},
                new CalisanHizmetler{CalisanHizmetID=52, CalisanID=4,HizmetID=6},
                new CalisanHizmetler{CalisanHizmetID=53, CalisanID=4,HizmetID=7},
                new CalisanHizmetler{CalisanHizmetID=54, CalisanID=4,HizmetID=8},
                new CalisanHizmetler{CalisanHizmetID=55, CalisanID=4,HizmetID=9},
                new CalisanHizmetler{CalisanHizmetID=56, CalisanID=4,HizmetID=10},
                new CalisanHizmetler{CalisanHizmetID=57, CalisanID=4,HizmetID=11},
                new CalisanHizmetler{CalisanHizmetID=58, CalisanID=4,HizmetID=12},
                new CalisanHizmetler{CalisanHizmetID=59, CalisanID=4,HizmetID=13},
                new CalisanHizmetler{CalisanHizmetID=60, CalisanID=4,HizmetID=14},
                new CalisanHizmetler{CalisanHizmetID=61, CalisanID=4,HizmetID=15},
                new CalisanHizmetler{CalisanHizmetID=62, CalisanID=4,HizmetID=16},
                new CalisanHizmetler{CalisanHizmetID=63, CalisanID=4,HizmetID=17},
                new CalisanHizmetler{CalisanHizmetID=64, CalisanID=4,HizmetID=18},
                new CalisanHizmetler{CalisanHizmetID=65, CalisanID=4,HizmetID=19},
                new CalisanHizmetler{CalisanHizmetID=66, CalisanID=4,HizmetID=20},
                new CalisanHizmetler{CalisanHizmetID=67, CalisanID=4,HizmetID=21},
                new CalisanHizmetler{CalisanHizmetID=68, CalisanID=4,HizmetID=22},
                new CalisanHizmetler{CalisanHizmetID=69, CalisanID=4,HizmetID=23},
                new CalisanHizmetler{CalisanHizmetID=70, CalisanID=4,HizmetID=24},
                new CalisanHizmetler{CalisanHizmetID=71, CalisanID=5,HizmetID=1},
                new CalisanHizmetler{CalisanHizmetID=72, CalisanID=5,HizmetID=2},
                new CalisanHizmetler{CalisanHizmetID=73, CalisanID=5,HizmetID=3},
                new CalisanHizmetler{CalisanHizmetID=74, CalisanID=5,HizmetID=4},
                new CalisanHizmetler{CalisanHizmetID=75, CalisanID=5,HizmetID=5},
                new CalisanHizmetler{CalisanHizmetID=76, CalisanID=6,HizmetID=17},
                new CalisanHizmetler{CalisanHizmetID=77, CalisanID=6,HizmetID=18},
                new CalisanHizmetler{CalisanHizmetID=78, CalisanID=6,HizmetID=19},
                new CalisanHizmetler{CalisanHizmetID=79, CalisanID=6,HizmetID=20},
                new CalisanHizmetler{CalisanHizmetID=80, CalisanID=6,HizmetID=21},
                new CalisanHizmetler{CalisanHizmetID=81, CalisanID=6,HizmetID=22},
                new CalisanHizmetler{CalisanHizmetID=82, CalisanID=6,HizmetID=23},
                new CalisanHizmetler{CalisanHizmetID=83, CalisanID=6,HizmetID=24},
                new CalisanHizmetler{CalisanHizmetID=84, CalisanID=7,HizmetID=17},
                new CalisanHizmetler{CalisanHizmetID=85, CalisanID=7,HizmetID=18},
                new CalisanHizmetler{CalisanHizmetID=86, CalisanID=7,HizmetID=19},
                new CalisanHizmetler{CalisanHizmetID=87, CalisanID=7,HizmetID=20},
                new CalisanHizmetler{CalisanHizmetID=88, CalisanID=7,HizmetID=21},
                new CalisanHizmetler{CalisanHizmetID=89, CalisanID=7,HizmetID=22},
                new CalisanHizmetler{CalisanHizmetID=90, CalisanID=7,HizmetID=23},
                new CalisanHizmetler{CalisanHizmetID=91, CalisanID=7,HizmetID=24}

                );

        }
    }
}
//1   1
//1   5
//2   2
//2   3
//2   4
//2   5
//2   6
//3   1
//3   3
//3   5
//3   6
//4   1
//4   2
//4   5
//4   6
//5   1
//5   5
//5   7
//6   2
//6   3
//6   5
//6   6
//6   7
//7   1
//7   3
//7   4
//7   7









//    protected override void OnModelCreating(ModelBuilder modelBuilder)
//    {
//        modelBuilder.Entity<Hizmetler>()
//            .Property(h => h.Fiyat)
//            .HasColumnType("decimal(18,2)"); // Burada (18,2) hassasiyeti ve ölçeği belirtir.



//        //modelBuilder.Entity<Randevu>()
//        //.HasOne(r => r.Musteriler) // Randevu tablosunun Musteriler ile olan ilişkisi
//        //.WithMany(m => m.Randevular) // Musteriler tablosunun Randevular ile olan ilişkisi
//        //.HasForeignKey(r => r.MusteriID) // Foreign key ayarı
//        //.OnDelete(DeleteBehavior.Cascade); // Müşteri silindiğinde randevular silinsin




//        //modelBuilder.Entity<CalisanGun>()
//        // .HasKey(cg => new { cg.CalisanID, cg.CalisanGunID });

//        //modelBuilder.Entity<CalisanGun>()
//        //    .HasOne(cg => cg.Calisan)
//        //    .WithMany(c => c.CalisanGunler)
//        //    .HasForeignKey(cg => cg.CalisanID);

//        //modelBuilder.Entity<CalisanGun>()
//        //    .HasOne(cg => cg.Gun)
//        //    .WithMany(g => g.CalisanGunler)
//        //    .HasForeignKey(cg => cg.CalisanGunID);
////        modelBuilder.Entity<Gunler>().HasData(
////    new Gunler { CalisanGunID = 1, GunAdi = "Pazartesi" },
////    new Gunler { CalisanGunID = 2, GunAdi = "Salı" },
////    new Gunler { CalisanGunID = 3, GunAdi = "Çarşamba" },
////    new Gunler { CalisanGunID = 4, GunAdi = "Perşembe" },
////    new Gunler { CalisanGunID = 5, GunAdi = "Cuma" },
////    new Gunler { CalisanGunID = 6, GunAdi = "Cumartesi" },
////    new Gunler { CalisanGunID = 7, GunAdi = "Pazar" }
////);

//        //     modelBuilder.Entity<Calisan>().HasData(
//        //    new Calisan { CalisanID = 1, CalisanAd = "Dilan", CalisanSoyad = "Kaya", CalisanTelefon = "05551234567", CalisanMail = "dilan.yilmaz@gmail.com",CalisanSifre="Dilan123" },
//        //    new Calisan { CalisanID = 2, CalisanAd = "Elif", CalisanSoyad = "Yılmaz", CalisanTelefon = "05552345678", CalisanMail = "elif.yilmaz@gmail.com", CalisanSifre = "Elif123" },
//        //    new Calisan { CalisanID = 3, CalisanAd = "Şeyma", CalisanSoyad = "Çetin", CalisanTelefon = "05553456789", CalisanMail = "seyma.cetin@gmail.com" , CalisanSifre = "Seyma123" },
//        //     new Calisan { CalisanID = 4, CalisanAd = "Ece", CalisanSoyad = "Tuncer", CalisanTelefon = "05551234567", CalisanMail = "ece.tuncer@gmail.com",CalisanSifre = "Ece123" },
//        //    new Calisan { CalisanID = 5, CalisanAd = "Aslı", CalisanSoyad = "Şahin", CalisanTelefon = "05552345678", CalisanMail = "asli.cetin@gmail.com" , CalisanSifre = "Asli123" },
//        //    new Calisan { CalisanID = 6, CalisanAd = "Ceyda", CalisanSoyad = "Özdemir", CalisanTelefon = "05553456789", CalisanMail = "ceyda.ozdemir@gmail.com", CalisanSifre = "Ceyda123" },
//        //     new Calisan { CalisanID = 7, CalisanAd = "Nisan", CalisanSoyad = "Kaya", CalisanTelefon = "05551234567", CalisanMail = "nisan.kaya@gmail.com" , CalisanSifre = "Nisan123" }
//        //);



//        //       modelBuilder.Entity<CalisanGun>().HasData(

//        //    new CalisanGun { CalisanID = 1, CalisanGunID = 1}, // Pazartesi
//        //    new CalisanGun { CalisanID = 1, CalisanGunID = 5 }, // cuma


//        //    new CalisanGun { CalisanID = 2, CalisanGunID = 2 }, // Çarşamba
//        //    new CalisanGun { CalisanID = 2, CalisanGunID = 3 }, // Perşembe
//        //    new CalisanGun { CalisanID = 2, CalisanGunID = 5 }, // Çarşamba
//        //    new CalisanGun { CalisanID = 2, CalisanGunID = 6 }, // Perşembe


//        //    new CalisanGun { CalisanID = 3, CalisanGunID = 1 }, // pzt
//        //    new CalisanGun { CalisanID = 3, CalisanGunID = 3},  //crs
//        //      new CalisanGun { CalisanID = 3, CalisanGunID = 5 }, // Cuma
//        //    new CalisanGun { CalisanID = 3, CalisanGunID = 6 } , // Cumartesi


//        //     new CalisanGun { CalisanID = 4, CalisanGunID = 1 }, // pzt
//        //    new CalisanGun { CalisanID = 4, CalisanGunID = 2 }, // sali
//        //    new CalisanGun { CalisanID = 4, CalisanGunID = 5 }, //cuma
//        //    new CalisanGun { CalisanID = 4, CalisanGunID = 6 }, //cmt


//        //     new CalisanGun { CalisanID = 5, CalisanGunID = 1 }, // pzt
//        //    new CalisanGun { CalisanID = 5, CalisanGunID = 5 }, // cuma
//        //    new CalisanGun { CalisanID = 5, CalisanGunID = 7 }, //pazar



//        //    new CalisanGun { CalisanID = 6, CalisanGunID = 2 }, //sali
//        //     new CalisanGun { CalisanID = 6, CalisanGunID = 3 }, // cars
//        //    new CalisanGun { CalisanID = 6, CalisanGunID = 5 }, // cuma
//        //    new CalisanGun { CalisanID = 6, CalisanGunID = 6 }, //cmt



//        //     new CalisanGun { CalisanID = 7, CalisanGunID = 1 }, // pzt
//        //    new CalisanGun { CalisanID = 7, CalisanGunID = 3 }, // sali
//        //    new CalisanGun { CalisanID = 7, CalisanGunID = 4 }, //cuma
//        //    new CalisanGun { CalisanID = 7, CalisanGunID = 7 } //cmt

//        //);




//    }



