using Microsoft.AspNetCore.Identity;

namespace IsRotasiProje.Models
{
    public class AppUser : IdentityUser
    {
        public string Ad { get; set; }
        public string? Image { get; set; }
        public string? Website { get; set; }
        public DateTime? DogumTarihi { get; set; }
        public string? Deneyim { get; set; }
        public string? Egitim { get; set; }
        public string? Ozet { get; set; }
        public string? Hobi { get; set; }
        public string? Bilgisayar { get; set; }
        public DateTime Tarih { get; set; }

        public virtual ICollection<Basvuru> Basvurus { get; set; } = new List<Basvuru>();
        public virtual ICollection<Ilan> Ilans { get; set; } = new List<Ilan>();
    }
}
