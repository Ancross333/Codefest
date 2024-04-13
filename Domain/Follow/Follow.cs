using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Follow
{
    public class Follow
    {
        public int Id { get; set; }
        public int FollowerId { get; set; }
        public int FolloweeId { get; set; }
    }
}
