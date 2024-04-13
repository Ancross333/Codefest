using Domain.Message;
using Db;
using Domain.Interfaces;

namespace Infrastructure.Repos
{
	public class MessagesRepository : IMessagesRepository
	{
		private readonly DinoNuggiesDbContext _dbContext;
		private const int MaxMessagesRetreivedInQuery = 10;

		public MessagesRepository(DinoNuggiesDbContext dbContext)
		{
			_dbContext = dbContext;
		}

		public List<Message> Get(int senderId, int receiverId, int oldestMessageId)
		{
			return _dbContext.Messages.AsParallel().OrderByDescending(m => m.Id)
				.Where(m => IsValidMessage(m, senderId, receiverId, oldestMessageId))
				.Take(MaxMessagesRetreivedInQuery).OrderBy(m => m.Id).ToList();
		}

		private static bool IsValidMessage(Message message, int senderId, int receiverId, int oldestMessageId)
		{
			return (message.SenderId == senderId || message.SenderId == receiverId) 
				&& (message.ReceiverId == receiverId || message.ReceiverId == senderId)
				&& message.Id < oldestMessageId;
		}
	}
}
