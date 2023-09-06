namespace IsRotasiProje.Models
{
    public class Pozisyon
    {
        public int PozisyonId { get; set; }

        public string PozisyonIsim { get; set; } = null!;

        public virtual ICollection<Ilan> Ilans { get; set; } = new List<Ilan>();
    }
}
