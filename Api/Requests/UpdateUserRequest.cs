using Domain;
using Domain.User;

namespace Api.Requests
{
    public class UpdateUserRequest
    {
        public string Email { get; set; }
        public string CompanyName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Zip Zip { get; set; }
        public AccountType AccountType { get; set; }
        public ProfilePicture ProfilePicture { get; set; }
    }
}
