namespace KuaforWebSitesi.Models
{
    public class Randevu
    {
        public int RandevuID { get; set; }
        public int? MusteriID { get; set; }
        public int? CalisanID { get; set; }
        public int? HizmetID { get; set; }
        public DateTime Tarih { get; set; }
        public TimeSpan Saat { get; set; }
        public string Durum { get; set; } = "Bekliyor"; // Randevu durumu (Onaylandı, Beklemede, İptal Edildi vb.)
        // Navigation properties
        public virtual Musteri Musteri { get; set; }
        public virtual Calisan Calisan { get; set; }
        public virtual Hizmetler Hizmet { get; set; }

    }
}
