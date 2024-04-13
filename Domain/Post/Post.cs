using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Post
{
    public class Post // Posts
    {
        public int Id { get; set; }
        public int PosterId { get; set; }
        public string Title { get; set; } // ImageUrl: String
        public DateTime CreatedAt { get; set; }
        public string Caption { get; set; }

        public Post(int posterId, string title, DateTime createdAt, string caption)
        {
            PosterId = posterId;
            Title = title;
            CreatedAt = createdAt;
            Caption = caption;
        }
    }
}
