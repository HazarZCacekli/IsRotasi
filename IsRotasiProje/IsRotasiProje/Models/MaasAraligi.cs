namespace IsRotasiProje.Models
{
    public class MaasAraligi
    {
        public int MaasAraligiId { get; set; }

        public string Aralik { get; set; } = null!;

        public virtual ICollection<Ilan> Ilans { get; set; } = new List<Ilan>();
    }
}
