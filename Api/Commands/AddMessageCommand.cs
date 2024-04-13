using MediatR;

namespace Api.Commands
{
	public class AddMessageCommand : IRequest<AddMessageDto>
	{
		public int SenderId { get; set; }
		public int ReceiverId { get; set; }
		public DateTime CreatedAt { get; set; }
		public string Content { get; set; }

		public AddMessageCommand(int senderId, int receiverId, DateTime createdAt, string content)
		{
			SenderId = senderId;
			ReceiverId = receiverId;
			CreatedAt = createdAt;
			Content = content;
		}
	}

	public record AddMessageDto
	{
        public int MessageId { get; set; }
    }
}
