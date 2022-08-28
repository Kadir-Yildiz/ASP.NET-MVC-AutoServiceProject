using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OtoServis.Entities.Servis
{
    public class Musteri
    {
        [Key]
        public int MusteriId { get; set; }
        [Required(ErrorMessage ="Ad Soyad / Unvan alanı boş geçilemez!")]
        [MaxLength(100)]
        public string AdSoyad { get; set; }
        [Required(ErrorMessage = "Telefon alanı boş geçilemez!")]
        [MaxLength(11)]
        public string Telefon { get; set; }
        [MaxLength(100)]
        public string Eposta { get; set; }
        [MaxLength(500)]
        public string Adres { get; set; }
    }
}
