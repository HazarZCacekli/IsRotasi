namespace IsRotasiProje.Models
{
    public class Ilan
    {
        public int IlanId { get; set; }

        public string IsTanimi { get; set; }

        public string AdayGereklilik { get; set; }

        public string UserId { get; set; }

        public int KategoriId { get; set; }

        public int SehirId { get; set; }

        public int CalismaSekliId { get; set; }

        public int PozisyonId { get; set; }

        public int MaasAraligiId { get; set; }
        public DateTime Tarih { get; set; }
        public string IlanAd { get; set; }

        public virtual ICollection<Basvuru> Basvurus { get; set; } = new List<Basvuru>();

        public virtual CalismaSekli CalismaSekli { get; set; }

        public virtual Kategori Kategori { get; set; }

        public virtual MaasAraligi MaasAraligi { get; set; }

        public virtual Pozisyon Pozisyon { get; set; }

        public virtual Sehir Sehir { get; set; }

        public virtual AppUser User { get; set; }
    }
}
