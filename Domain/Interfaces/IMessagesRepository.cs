using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Message;

namespace Domain.Interfaces
{
	public interface IMessagesRepository
	{
		Task<List<Message.Message>> GetMessages(int senderId, int receiverId, int oldestMessageId);
		Task AddAsync(Message.Message message);
		Task<List<Conversation>> GetConversations(int userId);
		Task SaveChangesAsync();
	}
}
