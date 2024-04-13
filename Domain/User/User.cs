using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.User
{
    public class User
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string? CompanyName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Zip Zip { get; set; }
        public AccountType AccountType { get; set; }
        public ProfilePicture ProfilePicture { get; set; }

		public User(string email, string password, string? companyName, string firstName, 
			string lastName, Zip zip, AccountType accountType, ProfilePicture profilePicture)
		{
			Email = email;
			Password = password;
			CompanyName = companyName;
			FirstName = firstName;
			LastName = lastName;
			Zip = zip;
			AccountType = accountType;
			ProfilePicture = profilePicture;
		}
	}
}
