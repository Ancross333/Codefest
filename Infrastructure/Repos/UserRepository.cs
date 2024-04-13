
using Db;
using Domain.Interfaces;
using Domain.User;

namespace Infrastructure.Repos
{
	public class UserRepository : IUserRepository
	{
		private readonly DinoNuggiesDbContext _dbContext;

		public UserRepository(DinoNuggiesDbContext dbContext)
		{
			_dbContext = dbContext;
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
	}
}
