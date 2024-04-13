
using Db;
using Domain.Interfaces;
using Domain.User;
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
	}
}
