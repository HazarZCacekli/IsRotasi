namespace IsRotasiProje.Models
{
    public class Basvuru
    {
        public int BasvuruId { get; set; }

        public int? IlanId { get; set; }

        public string? UserId { get; set; }

        public DateTime Tarih { get; set; }

        public virtual Ilan Ilan { get; set; }

        public virtual AppUser? User { get; set; }
    }
}
