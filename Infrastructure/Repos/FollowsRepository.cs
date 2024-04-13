
using Db;
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

	}
}
