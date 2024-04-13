using Domain.User;
using Domain.Values;

namespace Api.Requests
{
	public class SearchRequest
	{
        public List<Interest> Interests { get; set; }
		public List<Zip>? Zips { get; set; }
    }
}
