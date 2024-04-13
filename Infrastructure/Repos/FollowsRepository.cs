
using Db;
using Domain.Follow;
using Domain.Interfaces;

namespace Infrastructure.Repos
{
	public class FollowsRepository : IFollowsRepository
	{
		private readonly DinoNuggiesDbContext _dbContext;

		public FollowsRepository(DinoNuggiesDbContext dbContext)
		{
			_dbContext = dbContext;
		}

		public async Task AddAsync(Follow follow)
		{
			await _dbContext.Follows.AddAsync(follow);
		}

		public async Task SaveChangesAsync()
		{
			await _dbContext.SaveChangesAsync();
		}
	}
}
