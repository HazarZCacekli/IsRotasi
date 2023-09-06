using IsRotasiProje.Models;

namespace IsRotasiProje.ViewModel
{
	public class UserRoleAdminViewModel
	{
		public DateTime? Tarih { get; set; }
		public string UserId { get; set; }

		public string Ad { get; set; }
		public string RoleId { get; set; }
        public string Email { get; set; }
		public string Role { get; set; }
	}
}
