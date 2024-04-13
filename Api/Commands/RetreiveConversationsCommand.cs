using Domain.User;
using MediatR;
using Domain.Message;

namespace Api.Commands
{
	public class RetreiveConversationsCommand : IRequest<RetreiveConversationsDto>
	{
        public int UserId { get; set; }

		public RetreiveConversationsCommand(int userId)
		{
			UserId = userId;
		}
	}

	public record RetreiveConversationsDto
	{
        public List<Conversation> Conversations { get; set; }
	}

}
