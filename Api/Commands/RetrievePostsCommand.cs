using MediatR;
using Domain.Post;

namespace Api.Commands


{
    public class RetrievePostsCommand : IRequest<RetrievePostsDto>
    {
        public int UserId { get; set; }
        public int StartingPostId { get; set; }

        public RetrievePostsCommand(int userId, int startingPostId)
        {
            UserId = userId;
            StartingPostId = startingPostId;
        }
    }

    public record RetrievePostsDto
    {
        public List<Post> Posts { get; set; }
    }
}
