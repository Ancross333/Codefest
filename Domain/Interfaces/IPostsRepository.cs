using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Post;

namespace Domain.Interfaces
{
	public interface IPostsRepository
	{
		List<Post.Post> Get(int userId, int startingPostId);
	}
}
