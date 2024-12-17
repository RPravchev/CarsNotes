
namespace CarsNotes.Web.Areas.Admin.Models
{
	public class UsersViewModel
	{
		public string Id { get; set; } = null!;
		public string UserName { get; set; } = null!;
		public string? FirstName { get; set; }
		public string? LastName { get; set; }
		public string Email { get; set; } = null!;
		public string? Phone { get; set; } 
		public string? Role { get; set; }
		public bool IsDeleted { get; set; }
	}
}
