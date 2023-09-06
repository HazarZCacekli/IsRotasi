namespace IsRotasiProje.ViewModel
{
    public class IlanViewModel
    {
        public int Id { get; set; }

        public string IsTanimi { get; set; }

        public string AdayGereklilik { get; set; }

        public string Kategori { get; set; }
        public int KategoriId { get; set; }
        public string Ad { get; set; }

        public string Sehir { get; set; }
        public int SehirId { get; set; }
        public string CalismaSekli { get; set; }
        public int CalismaSekliId { get; set; }
        public string Pozisyon { get; set; }
        public int PozisyonId { get; set; }
        public string MaasAraligi { get; set; }
        public int MaasAraligiId { get; set; }
        public DateTime Tarih { get; set; }
        public string? Image { get; set; }
        public string IlanAd { get; set; }
        public string Email { get; set; }
        public string? Telefon { get; set; }
        public string? Website { get; set; }
        public string? Ozet { get; set; }
        public string UserId { get; set; }


    }
}
