
using Db;
using Domain.Interfaces;
using Domain.User;
using Domain.Values;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repos
{
	public class UserRepository : IUserRepository
	{
		private readonly DinoNuggiesDbContext _dbContext;

		public UserRepository(DinoNuggiesDbContext dbContext)
		{
			_dbContext = dbContext;
		}
		public async Task AddAsync(User user)
		{
			await _dbContext.Users.AddAsync(user);
		}

		public async Task SaveChangesAsync()
		{
			await _dbContext.SaveChangesAsync();
		}

		public async Task<User> GetAsync(string email, string password)
		{
            return await _dbContext.Users.FirstOrDefaultAsync(u => u.Email == email && u.Password == password);
        }

		public async Task UpdateAsync(string email, string companyName, string firstName, string lastName, Zip zip, AccountType accountType, ProfilePicture profilePicture)
		{
			var user = await _dbContext.Users.FirstOrDefaultAsync(u => u.Email == email);

			if(user != null)
			{
				if(email != null)
				{
                    user.Email = email;
                }

				if(companyName != null)
				{
                    user.CompanyName = companyName;
                }

				if(firstName != null)
				{
					user.FirstName = firstName;
				}

				if(lastName != null)
				{
                    user.LastName = lastName;
                }

				if(zip != user.Zip)
				{
                    user.Zip = zip;
                }

				if(accountType != user.AccountType)
				{
                    user.AccountType = accountType;
                }

				if(profilePicture != user.ProfilePicture)
				{
                    user.ProfilePicture = profilePicture;
                }

				await _dbContext.SaveChangesAsync();
			}
		}
	}
}
