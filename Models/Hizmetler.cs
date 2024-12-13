using System.ComponentModel.DataAnnotations;

namespace KuaforWebSitesi.Models
{
    public class Hizmetler
    {
        [Key]
        public int HizmetID { get; set; }

        [Required]
        public string HizmetAdi { get; set; }

        [Required]
        public TimeSpan Sure { get; set; } // Hizmetin süresi

        [Required]
        public decimal Fiyat { get; set; } // Hizmetin fiyatı
        public int HizmetKategoriID { get; set; }
        public HizmetKategori HizmetKategoriler { get; set; }  // Kategoriye bağlanma
       

        public ICollection<Randevu>? Randevular { get; set; }

        public ICollection<CalisanHizmetler>? CalisanHizmetler { get; set; }
    }
}
