
using Domain.Interfaces;
using Db;
using Domain.Post;

namespace Infrastructure.Repos
{
	public class PostsRepository : IPostsRepository
	{

		private readonly DinoNuggiesDbContext _dbContext;
		private const int MaxPostsRetrievedInQuery = 10;

		public PostsRepository(DinoNuggiesDbContext dbContext)
		{
            _dbContext = dbContext;
        }

		public List<Post> Get(int userId, int startingPostId)
		{
			return _dbContext.Posts.AsParallel().OrderByDescending( p => p.Id)
				.ToList();
		}



	}
}
