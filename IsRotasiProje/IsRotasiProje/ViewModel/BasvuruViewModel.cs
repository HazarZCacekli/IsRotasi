using IsRotasiProje.Models;

namespace IsRotasiProje.ViewModel
{
	public class BasvuruViewModel
	{
		public int BasvuruId { get; set; }

		public int? IlanId { get; set; }
		public string UserAd { get; set; }
        public string UserEmail { get; set; }
        public string UserId { get; set; }
		public DateTime Tarih { get; set; }
		public string Kategori { get; set; }
		public string IlanAd { get; set; }

	}
}
