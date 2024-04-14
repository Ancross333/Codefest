using MediatR;
using Domain.User;

namespace Api.Commands
{
    public class UpdateUserCommand : IRequest<UpdateUserDto>
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string CompanyName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Zip Zip { get; set; }
        public AccountType AccountType { get; set; }
        public ProfilePicture ProfilePicture { get; set; }

        public UpdateUserCommand( int id,string email, string companyName, string firstName, string lastName, Zip zip, AccountType accountType, ProfilePicture profilePicture)
        {
            Id = id;
            Email = email;
            CompanyName = companyName;
            FirstName = firstName;
            LastName = lastName;
            Zip = zip;
            AccountType = accountType;
            ProfilePicture = profilePicture;
        }
    }

    public record UpdateUserDto
    {
        public User User { get; set; }
    }
}
