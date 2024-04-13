
using Db;
using Domain.Interfaces;
using Domain.Values;

namespace Infrastructure.Repos
{
	public class ValuesRepository : IValuesRepository
	{
		private readonly DinoNuggiesDbContext _dbContext;

		public ValuesRepository(DinoNuggiesDbContext dbContext)
		{
			_dbContext = dbContext;
		}

		public async Task AddAsync(List<Interest> values, int userId)
		{
			foreach (Interest interest in values)
			{
				Values value = new(userId, interest);
				await _dbContext.Values.AddAsync(value);
			}
		}

		public async Task SaveChangesAsync()
		{
			await _dbContext.SaveChangesAsync();
		}
	}
}
