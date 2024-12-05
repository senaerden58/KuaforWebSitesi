using System.ComponentModel.DataAnnotations;

namespace KuaforWebSitesi.Models
{
    public class Calisan
    {
        [Key]
        public int CalisanID { get; set; }    
        public string CalisanAd { get; set; }
        public string CalisanSoyad { get; set; }

        public string CalisanMail { get; set; }

        public string CalisanTelefon { get; set; }

       public string CalisanOzellikler { get;set; }
    }
}
