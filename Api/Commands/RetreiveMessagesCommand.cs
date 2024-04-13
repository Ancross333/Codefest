using MediatR;
using Domain.Message;

namespace Api.Commands
{
	public class RetreiveMessagesCommand : IRequest<RetreiveMessagesDto>
	{
		public int SenderId { get; set; }
        public int ReceiverId { get; set; }
        public int OldestMessageId { get; set; }

		public RetreiveMessagesCommand(int senderId, int receiverId, int oldestMessageId)
		{
			SenderId = senderId;
			ReceiverId = receiverId;
			OldestMessageId = oldestMessageId;
		}
	}

	public record RetreiveMessagesDto
	{
		public List<Message> Messages { get; set; }
	}
}
