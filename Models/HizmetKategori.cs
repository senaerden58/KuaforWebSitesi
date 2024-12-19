using KuaforWebSitesi.Models;
using Microsoft.EntityFrameworkCore;

namespace KuaforWebSitesi.Models
{
    public class HizmetKategori
    {
        public int HizmetKategoriID { get; set; }  // Kategorinin ID'si
        public string KategoriAdi { get; set; }    // Kategori adı (Saç, Manikür vb.)

        public virtual ICollection<Hizmetler>? Hizmetler { get; set; }  // Bu kategoriye ait hizmetler
    }
}



