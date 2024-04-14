
using Common;
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

		public List<User>? Search(List<Interest> interests, List<Zip>? zips)
		{
			List<User>? result = new();
			foreach (Interest interest in interests)
			{
				List<Values> resultsByInterest = _dbContext.Values.AsParallel().Where(v =>
				{
					return v.Interest == interest;
				}).Distinct().ToList();
				resultsByInterest.Select(async v =>
				{
					int id = v.UserId;
					User? user = await GetAsync(id);
					if (user is not null)
					{
						result.Add(user);
					}
					return v;
				});
			}
			return result;
		}

		public async Task<User?> GetAsync(int id)
		{
			return _dbContext.Users.AsParallel().Where(u => u.Id == id).FirstOrDefault();
		}
		public async Task AddAsync(User user)
		{
			await _dbContext.Users.AddAsync(user);
		}

		public async Task SaveChangesAsync()
		{
			await _dbContext.SaveChangesAsync();
		}

        public async Task<User?> GetAsync(string email, string password)
        {
            // Retrieve the user by email only
            var user = await _dbContext.Users.FirstOrDefaultAsync(u => u.Email == email);

            // Verify the password in-memory, if user is found
            if (user != null && PasswordUtils.VerifyPassword(user.Password, password))
            {
                return user;
            }

            return null;
        }

		public bool EmailExists(string email)
		{
			return _dbContext.Users.Any(user => user.Email == email);
		}


        public async Task UpdateAsync(int id, string email, string companyName, string firstName, string lastName, Zip zip, AccountType accountType, ProfilePicture profilePicture)
		{
			var user = await _dbContext.Users.FirstOrDefaultAsync(u => u.Id == id);


			if(user != null)
			{
				if (email != null)
				{
					user.Email = email;
				}

				if (companyName != null)
				{
					user.CompanyName = companyName;
				}

				if (firstName != null)
				{
					user.FirstName = firstName;
				}

				if (lastName != null)
				{
					user.LastName = lastName;
				}

				if (zip != user.Zip)
				{
					user.Zip = zip;
				}

				if (accountType != user.AccountType)
				{
					user.AccountType = accountType;
				}

				if (profilePicture != user.ProfilePicture)
				{
					user.ProfilePicture = profilePicture;
				}

				await _dbContext.SaveChangesAsync();
			}
		}
	}
}
