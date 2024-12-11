using System.ComponentModel.DataAnnotations;

namespace KuaforWebSitesi.Models
{
    public class CalisanGun
    {
        [Key]
        public int CalisanGunID { get; set; }
        public int CalisanID { get; set; }
        public virtual Calisan Calisanlar { get; set; }

        public int GunID { get; set; }
        public virtual Gunler Gunler { get; set; }
    }
}
