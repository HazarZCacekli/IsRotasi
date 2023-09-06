namespace IsRotasiProje.Models
{
    public class CalismaSekli
    {
        public int CalismaSekliId { get; set; }

        public string CalismaSekliIsim { get; set; }

        public virtual ICollection<Ilan> Ilans { get; set; } = new List<Ilan>();
    }
}
