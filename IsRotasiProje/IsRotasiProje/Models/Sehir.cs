namespace IsRotasiProje.Models
{
    public class Sehir
    {
        public int SehirId { get; set; }

        public string SehirIsim { get; set; } = null!;

        public virtual ICollection<Ilan> Ilans { get; set; } = new List<Ilan>();
    }
}
