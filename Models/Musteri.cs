using System.ComponentModel.DataAnnotations;

namespace KuaforWebSitesi.Models
{
    public class Musteri
    {
        [Key]
        public int MusteriID { get; set; }



        [Required(ErrorMessage = "Lütfen Adınızı Giriniz")]
        [MinLength(3, ErrorMessage = "Ad alanı minimum 3 karakter olmalı")]
        [MaxLength(20, ErrorMessage = "Ad alanı Makismum 20 karakter olmalı")]
        public string MusteriAd { get; set; }



        [Required(ErrorMessage = "Lütfen Soyadınızı Giriniz:")]
        public string MusteriSoyad { get; set; }



        [Required(ErrorMessage = "Lütfen E-Mailinizi Giriniz.")]
        [EmailAddress(ErrorMessage = "Mail adresi uygun değil")]
        public string MusteriMail { get; set; }




        [Required(ErrorMessage = "Lütfen Telefon Numarasını Giriniz")]
        [RegularExpression(@"^(\+90|0)?[1-9][0-9]{9}$", ErrorMessage = "Geçerli bir telefon numarası giriniz")]

        public string MusteriTelefon { get; set; }



        [Required(ErrorMessage = "Lütfen şifre oluşturunuz.")]
        [MinLength(6, ErrorMessage = "Şifre en az 6 karakter olmalıdır.")]
        [RegularExpression(@"^(?=.*[A-Z])(?=.*\d)[A-Za-z\d@$!%*?&]{6,}$",
        ErrorMessage = "Şifre en az 6 karakter olmalı, en az 1 büyük harf ve en az 1 rakam içermelidir.")]
        public string MusteriSifre { get; set; }



        //[Required(ErrorMessage = "Şifreyi tekrar giriniz.")]
        //[Compare("MusteriSifre", ErrorMessage = "Şifreler eşleşmiyor.")]
        //public string MusteriSifreTekrar { get; set; }



        public virtual ICollection<Randevu> Randevular { get; set; } = new List<Randevu>();
    }
}
//using Microsoft.EntityFrameworkCore;
//using System.ComponentModel.DataAnnotations;

//namespace KuaforWebSitesi.Models
//{
//    public class Randevu
//    {
//        [Key]
//        public int RandevuID { get; set; }


//        public int? MusteriID { get; set; }
//        public Musteri Musteriler { get; set; }


//        public int CalisanID { get; set; }
//        public Calisan Calisanlar { get; set; }


//        public int HizmetID { get; set; }
//        public Hizmetler Hizmetler { get; set; }

//        [Required]
//        public DateTime RandevuTarihi { get; set; } // Randevu tarihi ve saati

//        [Required]
//        public TimeSpan BaslangicSaati { get; set; } // Randevunun başlangıç saati

//        [Required]
//        public TimeSpan BitisSaati { get; set; } // Randevunun bitiş saati

//        public bool Onaylandi { get; set; } // Randevunon onay durumu
//    }
//}
////public bool RandevuKapsamaKontrol(int calisanID, DateTime tarih, TimeSpan baslangicSaati, TimeSpan bitisSaati)
////{
////    // Veritabanında aynı tarihte ve çalışanda var olan randevuları sorgulama
////    var randevular = dbContext.Randevular
////        .Where(r => r.CalisanID == calisanID && r.RandevuTarihi.Date == tarih.Date)
////        .ToList();

////    foreach (var randevu in randevular)
////    {
////        if ((baslangicSaati < randevu.BitisSaati && bitisSaati > randevu.BaslangicSaati))
////        {
////            return false; // Çakışma var
////        }
////    }

////    return true; // Çakışma yok
////}
////using Microsoft.EntityFrameworkCore;
////using System.ComponentModel.DataAnnotations;

////namespace KuaforWebSitesi.Models
////{
////    public class Randevu
////    {
////        [Key]
////        public int RandevuID { get; set; }

////        [Required]
////        public int MusteriID { get; set; }
////        public Musteri Musteriler { get; set; }

////        [Required]
////        public int CalisanID { get; set; }
////        public Calisan Calisanlar { get; set; }

////        [Required]
////        public int HizmetID { get; set; }
////        public Hizmetler Hizmetler { get; set; }

////        [Required]
////        public DateTime RandevuTarihi { get; set; } // Randevu tarihi ve saati

////        [Required]
////        public TimeSpan BaslangicSaati { get; set; } // Randevunun başlangıç saati

////        [Required]
////        public TimeSpan BitisSaati { get; set; } // Randevunun bitiş saati

////        public bool Onaylandi { get; set; } // Randevunon onay durumu
////    }
////}
//////public bool RandevuKapsamaKontrol(int calisanID, DateTime tarih, TimeSpan baslangicSaati, TimeSpan bitisSaati)
//////{
//////    // Veritabanında aynı tarihte ve çalışanda var olan randevuları sorgulama
//////    var randevular = dbContext.Randevular
//////        .Where(r => r.CalisanID == calisanID && r.RandevuTarihi.Date == tarih.Date)
//////        .ToList();

//////    foreach (var randevu in randevular)
//////    {
//////        if ((baslangicSaati < randevu.BitisSaati && bitisSaati > randevu.BaslangicSaati))
//////        {
//////            return false; // Çakışma var
//////        }
//////    }

//////    return true; // Çakışma yok
//////}
