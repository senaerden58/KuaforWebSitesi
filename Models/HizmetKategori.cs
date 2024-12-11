namespace KuaforWebSitesi.Models
{
    public class HizmetKategori
    {
        public int HizmetKategoriID { get; set; }  // Kategorinin ID'si
        public string KategoriAdi { get; set; }    // Kategori adı (Saç, Manikür vb.)

        public ICollection<Hizmetler> Hizmetler { get; set; }  // Bu kategoriye ait hizmetler
    }
}
