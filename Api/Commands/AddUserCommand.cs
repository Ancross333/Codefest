using Domain.User;
using Domain.Values;
using MediatR;

namespace Api.Commands
{
	public class AddUserCommand : IRequest<AddUserDto>
	{
		public string Email { get; set; }
		public string Password { get; set; }
		public string? CompanyName { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public Zip Zip { get; set; }
		public AccountType AccountType { get; set; }
		public List<Values> Values { get; set; }

		public AddUserCommand(string email, string password, string? companyName, 
			string firstName, string lastName, Zip zip, AccountType accountType, List<Values> values)
		{
			Email = email;
			Password = password;
			CompanyName = companyName;
			FirstName = firstName;
			LastName = lastName;
			Zip = zip;
			AccountType = accountType;
			Values = values;
		}
	}

	public record AddUserDto
	{
        public int UserId { get; set; }
    }
}
