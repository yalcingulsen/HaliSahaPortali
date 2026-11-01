using System.ComponentModel.DataAnnotations;

namespace HaliSahaPortali.Models
{
    public class Rezervasyon
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Tarih zorunludur.")]
        public DateOnly Tarih { get; set; }

        [Range(8, 23, ErrorMessage = "Saat 08 ile 23 arasında olmalıdır.")]
        public int BaslangicSaati { get; set; }

        public bool IptalEdildi { get; set; }

        public int SahaId { get; set; }
        public Saha? Saha { get; set; }
    }
}