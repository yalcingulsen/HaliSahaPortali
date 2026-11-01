using System.ComponentModel.DataAnnotations;

namespace HaliSahaPortali.Models
{
    public class Yorum
    {
        public int Id { get; set; }

        [Range(1, 5, ErrorMessage = "Puan 1 ile 5 arasında olmalıdır.")]
        public int Puan { get; set; }

        [Required(ErrorMessage = "Yorum metni zorunludur.")]
        [StringLength(500)]
        public string Metin { get; set; } = string.Empty;

        public DateTime Tarih { get; set; } = DateTime.UtcNow;

        public int TesisId { get; set; }
        public Tesis? Tesis { get; set; }
    }
}