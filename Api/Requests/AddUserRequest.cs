using Domain.User;
using Domain.Values;
namespace Api.Requests
{
	public class AddUserRequest
	{
        public string Email { get; set; }
        public string Password { get; set; }
        public string? CompanyName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Zip Zip { get; set; }
        public AccountType AccountType { get; set; }
        public List<Interest> Values { get; set; }
		public ProfilePicture ProfilePicture { get; set; }
	}
}
