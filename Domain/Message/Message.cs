using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Message
{
    public class Message
    {
        public int Id { get; set; }
        public int SenderId { get; set; }
        public int ReceiverId { get; set; }
        public DateTime CreatedAt { get; set; }
        public string Content { get; set; }

        public Message(int senderId, int receiverId, DateTime createdAt, string content)
        {
            SenderId = senderId;
            ReceiverId = receiverId;
            CreatedAt = createdAt;
            Content = content;
        }
    }
}
