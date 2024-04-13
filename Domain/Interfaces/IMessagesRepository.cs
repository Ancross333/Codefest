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
		List<Message.Message> Get(int senderId, int receiverId, int oldestMessageId);
	}
}
