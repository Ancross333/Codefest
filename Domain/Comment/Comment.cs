﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Comments
{
    public class Comment
    {
        public int Id { get; set; }
        public int CommenterId { get; set; }
        public int PostId { get; set; }
        public DateTime CreatedAt { get; set; }
        public string Content { get; set; }
    }
}
