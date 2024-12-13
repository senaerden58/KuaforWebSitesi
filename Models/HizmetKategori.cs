using KuaforWebSitesi.Models;
using Microsoft.EntityFrameworkCore;

namespace KuaforWebSitesi.Models
{
    public class HizmetKategori
    {
        public int HizmetKategoriID { get; set; }  // Kategorinin ID'si
        public string KategoriAdi { get; set; }    // Kategori adı (Saç, Manikür vb.)

        public virtual ICollection<Hizmetler> Hizmetler { get; set; }  // Bu kategoriye ait hizmetler
    }
}

//using System;
//using Microsoft.EntityFrameworkCore;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;
//using System.Data;


//namespace KuaforWebSitesi.Models
//{
//    public class KuaforDBContext : DbContext
//    {
//        public KuaforDBContext(DbContextOptions<KuaforDBContext> options) : base(options)
//        {
//        }


//        //public DbSet<Musteri> Musteriler { get; set; }
//        //public DbSet<Calisan> Calisanlar { get; set; }
//        //public DbSet<Hizmetler> Hizmetler { get; set; }
//        //public DbSet<Randevu> Randevular { get; set; }
//        ////public DbSet<Admin> Adminler { get; set; }
//        //public DbSet<CalisanHizmetler> CalisanHizmetler { get; set; }
//        //public DbSet<Gunler> Gunler { get; set; }
//        //public DbSet<HizmetKategori> HizmetKategoriler { get; set; }
//        //public DbSet<CalisanGun> CalisanGunler { get; set; }

//        //    protected override void OnModelCreating(ModelBuilder modelBuilder)
//        //    {
//        //        modelBuilder.Entity<Hizmetler>()
//        //            .Property(h => h.Fiyat)
//        //            .HasColumnType("decimal(18,2)"); // Burada (18,2) hassasiyeti ve ölçeği belirtir.

//        //        // Çalışan ve Günler arasındaki ilişkiyi belirtiriz
//        //        modelBuilder.Entity<CalisanGun>()
//        //            .HasOne(cg => cg.Calisanlar)
//        //            .WithMany(c => c.CalisanGunler)
//        //            .HasForeignKey(cg => cg.CalisanID);

//        //        modelBuilder.Entity<CalisanGun>()
//        //            .HasOne(cg => cg.Gunler)
//        //            .WithMany(g => g.CalisanGunler)
//        //            .HasForeignKey(cg => cg.GunID);

//        //        modelBuilder.Entity<Hizmetler>()
//        //             .HasOne(h => h.HizmetKategori)   // Hizmetler tablosunun bir HizmetKategori'ye ait olduğunu belirtiyoruz
//        //             .WithMany(k => k.Hizmetler)     // HizmetKategori tablosunun birden fazla Hizmetler içerebileceğini belirtiyoruz
//        //             .HasForeignKey(h => h.HizmetKategoriID); // Yabancı anahtar ilişkisini kuruyoruz


//        //        modelBuilder.Entity<CalisanHizmetler>()
//        //            .HasOne(ch => ch.Calisan)
//        //                .WithMany(c => c.CalisanHizmetler)
//        //    .HasForeignKey(ch => ch.CalisanID);

//        //        modelBuilder.Entity<CalisanHizmetler>()
//        //            .HasOne(ch => ch.Hizmet)
//        //            .WithMany(h => h.CalisanHizmetler)
//        //            .HasForeignKey(ch => ch.HizmetID);

//        //        // Randevu ile Musteri arasındaki ilişki
//        //        modelBuilder.Entity<Randevu>()
//        //            .HasOne(r => r.Musteri)
//        //            .WithMany(m => m.Randevular)
//        //            .HasForeignKey(r => r.MusteriID)
//        //            .OnDelete(DeleteBehavior.Cascade); // Müşteri silindiğinde randevuları silinsin.

//        //        // Randevu ile Calisan arasındaki ilişki
//        //        modelBuilder.Entity<Randevu>()
//        //            .HasOne(r => r.Calisan)
//        //            .WithMany(c => c.Randevular)
//        //            .HasForeignKey(r => r.CalisanID)
//        //            .OnDelete(DeleteBehavior.Restrict); // Çalışan silindiğinde randevular etkilenmesin.

//        //        // Randevu ile Hizmet arasındaki ilişki
//        //        modelBuilder.Entity<Randevu>()
//        //            .HasOne(r => r.Hizmet)
//        //            .WithMany(h => h.Randevular)
//        //            .HasForeignKey(r => r.HizmetID)
//        //            .OnDelete(DeleteBehavior.Restrict); // Hizmet silindiğinde randevular etkilenmesin.
//        //    }

//        //}



//    }











////    protected override void OnModelCreating(ModelBuilder modelBuilder)
////    {
////        modelBuilder.Entity<Hizmetler>()
////            .Property(h => h.Fiyat)
////            .HasColumnType("decimal(18,2)"); // Burada (18,2) hassasiyeti ve ölçeği belirtir.



////        //modelBuilder.Entity<Randevu>()
////        //.HasOne(r => r.Musteriler) // Randevu tablosunun Musteriler ile olan ilişkisi
////        //.WithMany(m => m.Randevular) // Musteriler tablosunun Randevular ile olan ilişkisi
////        //.HasForeignKey(r => r.MusteriID) // Foreign key ayarı
////        //.OnDelete(DeleteBehavior.Cascade); // Müşteri silindiğinde randevular silinsin




////        //modelBuilder.Entity<CalisanGun>()
////        // .HasKey(cg => new { cg.CalisanID, cg.CalisanGunID });

////        //modelBuilder.Entity<CalisanGun>()
////        //    .HasOne(cg => cg.Calisan)
////        //    .WithMany(c => c.CalisanGunler)
////        //    .HasForeignKey(cg => cg.CalisanID);

////        //modelBuilder.Entity<CalisanGun>()
////        //    .HasOne(cg => cg.Gun)
////        //    .WithMany(g => g.CalisanGunler)
////        //    .HasForeignKey(cg => cg.CalisanGunID);
//////        modelBuilder.Entity<Gunler>().HasData(
//////    new Gunler { CalisanGunID = 1, GunAdi = "Pazartesi" },
//////    new Gunler { CalisanGunID = 2, GunAdi = "Salı" },
//////    new Gunler { CalisanGunID = 3, GunAdi = "Çarşamba" },
//////    new Gunler { CalisanGunID = 4, GunAdi = "Perşembe" },
//////    new Gunler { CalisanGunID = 5, GunAdi = "Cuma" },
//////    new Gunler { CalisanGunID = 6, GunAdi = "Cumartesi" },
//////    new Gunler { CalisanGunID = 7, GunAdi = "Pazar" }
//////);

////        //     modelBuilder.Entity<Calisan>().HasData(
////        //    new Calisan { CalisanID = 1, CalisanAd = "Dilan", CalisanSoyad = "Kaya", CalisanTelefon = "05551234567", CalisanMail = "dilan.yilmaz@gmail.com",CalisanSifre="Dilan123" },
////        //    new Calisan { CalisanID = 2, CalisanAd = "Elif", CalisanSoyad = "Yılmaz", CalisanTelefon = "05552345678", CalisanMail = "elif.yilmaz@gmail.com", CalisanSifre = "Elif123" },
////        //    new Calisan { CalisanID = 3, CalisanAd = "Şeyma", CalisanSoyad = "Çetin", CalisanTelefon = "05553456789", CalisanMail = "seyma.cetin@gmail.com" , CalisanSifre = "Seyma123" },
////        //     new Calisan { CalisanID = 4, CalisanAd = "Ece", CalisanSoyad = "Tuncer", CalisanTelefon = "05551234567", CalisanMail = "ece.tuncer@gmail.com",CalisanSifre = "Ece123" },
////        //    new Calisan { CalisanID = 5, CalisanAd = "Aslı", CalisanSoyad = "Şahin", CalisanTelefon = "05552345678", CalisanMail = "asli.cetin@gmail.com" , CalisanSifre = "Asli123" },
////        //    new Calisan { CalisanID = 6, CalisanAd = "Ceyda", CalisanSoyad = "Özdemir", CalisanTelefon = "05553456789", CalisanMail = "ceyda.ozdemir@gmail.com", CalisanSifre = "Ceyda123" },
////        //     new Calisan { CalisanID = 7, CalisanAd = "Nisan", CalisanSoyad = "Kaya", CalisanTelefon = "05551234567", CalisanMail = "nisan.kaya@gmail.com" , CalisanSifre = "Nisan123" }
////        //);



////        //       modelBuilder.Entity<CalisanGun>().HasData(

////        //    new CalisanGun { CalisanID = 1, CalisanGunID = 1}, // Pazartesi
////        //    new CalisanGun { CalisanID = 1, CalisanGunID = 5 }, // cuma


////        //    new CalisanGun { CalisanID = 2, CalisanGunID = 2 }, // Çarşamba
////        //    new CalisanGun { CalisanID = 2, CalisanGunID = 3 }, // Perşembe
////        //    new CalisanGun { CalisanID = 2, CalisanGunID = 5 }, // Çarşamba
////        //    new CalisanGun { CalisanID = 2, CalisanGunID = 6 }, // Perşembe


////        //    new CalisanGun { CalisanID = 3, CalisanGunID = 1 }, // pzt
////        //    new CalisanGun { CalisanID = 3, CalisanGunID = 3},  //crs
////        //      new CalisanGun { CalisanID = 3, CalisanGunID = 5 }, // Cuma
////        //    new CalisanGun { CalisanID = 3, CalisanGunID = 6 } , // Cumartesi


////        //     new CalisanGun { CalisanID = 4, CalisanGunID = 1 }, // pzt
////        //    new CalisanGun { CalisanID = 4, CalisanGunID = 2 }, // sali
////        //    new CalisanGun { CalisanID = 4, CalisanGunID = 5 }, //cuma
////        //    new CalisanGun { CalisanID = 4, CalisanGunID = 6 }, //cmt


////        //     new CalisanGun { CalisanID = 5, CalisanGunID = 1 }, // pzt
////        //    new CalisanGun { CalisanID = 5, CalisanGunID = 5 }, // cuma
////        //    new CalisanGun { CalisanID = 5, CalisanGunID = 7 }, //pazar



////        //    new CalisanGun { CalisanID = 6, CalisanGunID = 2 }, //sali
////        //     new CalisanGun { CalisanID = 6, CalisanGunID = 3 }, // cars
////        //    new CalisanGun { CalisanID = 6, CalisanGunID = 5 }, // cuma
////        //    new CalisanGun { CalisanID = 6, CalisanGunID = 6 }, //cmt



////        //     new CalisanGun { CalisanID = 7, CalisanGunID = 1 }, // pzt
////        //    new CalisanGun { CalisanID = 7, CalisanGunID = 3 }, // sali
////        //    new CalisanGun { CalisanID = 7, CalisanGunID = 4 }, //cuma
////        //    new CalisanGun { CalisanID = 7, CalisanGunID = 7 } //cmt

////        //);




////    }



