using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace IsRotasiProje.ViewModel
{
    public class UserViewModel
    {
        public string UserId { get; set; }

        public string Ad { get; set; }

        public string Email { get; set; }

        [ValidateNever]
        public IFormFile? ImagePath { get; set; }
        [ValidateNever]
        public string? Image { get; set; }

        public string? Telefon { get; set; }

        public string? Website { get; set; }

        public string? Adres { get; set; }

        public DateTime? DogumTarihi { get; set; }

        public string PasswordHash { get; set; }
        public string? Deneyim { get; set; }
        public string? Egitim { get; set; }
        public string? Ozet { get; set; }
        public string? Hobi { get; set; }
        public string? Bilgisayar { get; set; }
    }
}
