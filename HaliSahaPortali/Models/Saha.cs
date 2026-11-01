using System.ComponentModel.DataAnnotations;

namespace HaliSahaPortali.Models
{
    public class Saha
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Saha adı zorunludur.")]
        [StringLength(100)]
        public string Ad { get; set; } = string.Empty;

        [Required(ErrorMessage = "Zemin türü zorunludur.")]
        [StringLength(50)]
        public string ZeminTuru { get; set; } = string.Empty;

        public bool KapaliMi { get; set; }

        [Range(1, 10000, ErrorMessage = "Ücret 1 ile 10000 arasında olmalıdır.")]
        public decimal SaatlikUcret { get; set; }

        public int TesisId { get; set; }
        public Tesis? Tesis { get; set; }

        public List<Rezervasyon> Rezervasyonlar { get; set; } = new();
    }
}