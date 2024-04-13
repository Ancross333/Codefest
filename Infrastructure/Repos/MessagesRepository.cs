using Domain.Message;
using Db;
using Domain.Interfaces;
using Domain.User;
using System.Reflection.Metadata.Ecma335;

namespace Infrastructure.Repos
{
	public class MessagesRepository : IMessagesRepository
	{
		private readonly DinoNuggiesDbContext _dbContext;
		private const int MaxMessagesRetreivedInQuery = 10;
		private readonly IUserRepository _repository;

		public MessagesRepository(DinoNuggiesDbContext dbContext, IUserRepository repository)
		{
			_dbContext = dbContext;
			_repository = repository;
		}

		public async Task<List<Message>> GetMessages(int senderId, int receiverId, int oldestMessageId)
		{
			return _dbContext.Messages.AsParallel().OrderByDescending(m => m.Id)
				.Where(m => IsValidMessage(m, senderId, receiverId, oldestMessageId))
				.Take(MaxMessagesRetreivedInQuery).OrderBy(m => m.Id).ToList();
		}

		public async Task<List<Conversation>> GetConversations(int userId)
		{
			List<int> otherIds = _dbContext.Messages.AsParallel().Where(m =>
			{
				return m.SenderId == userId || m.ReceiverId == userId;
			}).Select(m =>
			{
				return m.SenderId == userId ? m.ReceiverId : m.SenderId;
			}).Distinct().ToList();
			return otherIds.Select(async other =>
			{
				User? otherUser = await _repository.GetAsync(other);
				Conversation conversation = new(otherUser.ProfilePicture, otherUser.FirstName, otherUser.LastName, other);
				return conversation;
			}).Select(conversation => conversation.Result).ToList();
		}

		private static bool IsValidMessage(Message message, int senderId, int receiverId, int oldestMessageId)
		{
			return (message.SenderId == senderId || message.SenderId == receiverId) 
				&& (message.ReceiverId == receiverId || message.ReceiverId == senderId)
				&& message.Id < oldestMessageId;
		}

		public async Task AddAsync(Message message)
		{
			await _dbContext.Messages.AddAsync(message);
		}

		public async Task SaveChangesAsync()
		{
			await _dbContext.SaveChangesAsync();
		}
	}
}
