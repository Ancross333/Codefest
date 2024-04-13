using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Values
{
    public class Values
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public Interest Interest { get; set; }

        public Values(int userId, Interest interest)
        {
            UserId = userId;
            Interest = interest;
        }
    }
}
