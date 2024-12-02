using System.ComponentModel.DataAnnotations;

namespace KuaforWebSitesi.Models
{
    public class Musteri
    {
      
        [Required(ErrorMessage = "Lütfen Adınızı Giriniz")]
        [MinLength(3, ErrorMessage = "Ad alanı minimum 3 karakter olmalı")]
        [MaxLength(20, ErrorMessage = "Ad alanı Makismum 20 karakter olmalı")]
        public required string MusteriAd { get; set; }

      
      
        [Required(ErrorMessage = "Lütfen Soyadınızı Giriniz:")]
        public required string MusteriSoyad { get; set; }

        
       
        [Required(ErrorMessage = "Lütfen E-Mailinizi Giriniz.")]
        [EmailAddress(ErrorMessage = "Mail adresi uygun değil")]
        public required string MusteriMail { get; set; }


        [Required(ErrorMessage = "Lütfen Telefon Numarasını Giriniz")]
        [RegularExpression(@"^(\+90|0)?[1-9][0-9]{9}$", ErrorMessage = "Geçerli bir telefon numarası giriniz")]
      
        public required string MusteriTelefon { get; set; }


    }
}
