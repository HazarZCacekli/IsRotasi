namespace IsRotasiProje.Models
{
    public class Kategori
    {
        public int KategoriId { get; set; }

        public string KategoriIsim { get; set; } = null!;

        public virtual ICollection<Ilan> Ilans { get; set; } = new List<Ilan>();
    }
}
