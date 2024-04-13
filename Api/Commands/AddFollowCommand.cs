using MediatR;

namespace Api.Commands
{
	public class AddFollowCommand : IRequest<AddFollowDto>
	{
		public int FollowerId { get; set; }
		public int FolloweeId { get; set; }

		public AddFollowCommand(int followerId, int followeeId)
		{
			FollowerId = followerId;
			FolloweeId = followeeId;
		}
	}

	public record AddFollowDto
	{
        public int FollowerId { get; set; }
        public int FolloweeId { get; set; }
    }
}
