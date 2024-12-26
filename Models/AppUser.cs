using Microsoft.AspNetCore.Identity;

namespace Curdoperation_Problem_.Models
{
	public class AppUser:IdentityUser
	{
		public string FirstName {  get; set; }
		public string LastName { get; set; }
		public string MobileNo {  get; set; }
		public string Address {  get; set; }

	}
}
