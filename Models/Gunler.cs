using System.ComponentModel.DataAnnotations;

namespace KuaforWebSitesi.Models
{
    public class Gunler
    {
        [Key]
        public int GunID { get; set; }

        [Required]
        public string GunAdi { get; set; } // Pazartesi, Salı, Çarşamba vb.
        public virtual ICollection<CalisanGun> CalisanGunler { get; set; }  // Hangi çalışanların hangi günlerde çalıştığını tutar

    }
}
