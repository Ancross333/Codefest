
using Domain.Interfaces;

namespace Infrastructure.Repos
{
	public class MessagesRepository : IMessagesRepository
	{
		private readonly DinoNuggiesDbContext _dbContext;

		public MessagesRepository(DinoNuggiesDbContext dbContext)
		{
			_dbContext = dbContext;
		}

		public List<Message> Get(int senderId, int receiverId, int oldestMessageId)
		{
			return _dbContext.Messages.AsParallel().Where(m => IsValidMessage(m, senderId, receiverId, oldestMessageId))
				.OrderByDescending(m => m.Id).ToList();
		}

		private static bool IsValidMessage(Message message, int senderId, int receiverId, int oldestMessageId)
		{
			return (message.senderId == senderId || message.senderId == receiverId) 
				&& (message.receiverId == receiverId || message.receiverId == senderId)
				&& message.Id < oldestMessageId;
		}
	}
}
