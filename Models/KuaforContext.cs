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

        }

    }
}











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



