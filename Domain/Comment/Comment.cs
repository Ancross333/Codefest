using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Comment
{
    public class Comment
    {
        public int Id { get; set; }
        public int CommenterId { get; set; }
        public int PostId { get; set; }
        public DateTime CreatedAt { get; set; }
        public string Content { get; set; }

        public Comment(int commenterId, int postId, DateTime createdAt, string content)
        {
            CommenterId = commenterId;
            PostId = postId;
            CreatedAt = createdAt;
            Content = content;
        }
    }
}
