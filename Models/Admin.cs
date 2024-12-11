using System.ComponentModel.DataAnnotations;

namespace KuaforWebSitesi.Models
{
    public class Admin
    {
        [Key]
        public int AdminID { get; set; }
        [Required]
        [EmailAddress]
        public string AdminMail { get; set; }

        [Required]
        [MinLength(3)]
        public string AdminSifre { get; set; }
        

    }
}
