namespace KuaforWebSitesi.Models
{
    public class RandevuViewModel
    {
        public int RandevuID { get; set; }
        public List<Calisan> Calisanlar { get; set; }
        public List<Hizmetler> Hizmetler { get; set; }
        public List<Gunler> Gunler { get; set; }

        // Seçilen çalışan ve hizmet bilgileri
        public int SeçilenCalisanID { get; set; }
        public int SeçilenHizmetID { get; set; }

        // Yeni eklenen tarih ve saat bilgileri
        public DateTime RandevuTarihi { get; set; }  // Randevu tarihi
        public TimeSpan RandevuSaati { get; set; }  // Randevu saati
    }
}
