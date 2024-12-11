using System.ComponentModel.DataAnnotations;

namespace KuaforWebSitesi.Models
{
    public class CalisanHizmetler
    {
        [Key]
        public int CalisanHizmetID { get; set; }

        [Required]
        public int CalisanID { get; set; }
        public Calisan Calisan { get; set; }

        [Required]
        public int HizmetID { get; set; }
        public Hizmetler Hizmetler { get; set; }


    }
}
