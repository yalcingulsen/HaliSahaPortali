using System.ComponentModel.DataAnnotations;

namespace HaliSahaPortali.Models
{
    public class Tesis
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Tesis adı zorunludur.")]
        [StringLength(100)]
        public string Ad { get; set; } = string.Empty;

        [Required(ErrorMessage = "Adres zorunludur.")]
        [StringLength(250)]
        public string Adres { get; set; } = string.Empty;

        [Required(ErrorMessage = "İlçe zorunludur.")]
        [StringLength(50)]
        public string Ilce { get; set; } = string.Empty;

        [Required(ErrorMessage = "Telefon zorunludur.")]
        [Phone]
        public string Telefon { get; set; } = string.Empty;

        [StringLength(500)]
        public string? Aciklama { get; set; }

        public List<Saha> Sahalar { get; set; } = new();
        public List<Yorum> Yorumlar { get; set; } = new();
    }
}