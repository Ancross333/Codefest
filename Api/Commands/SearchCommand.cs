using MediatR;
using Domain.User;
using Domain.Values;

namespace Api.Commands
{
	public class SearchCommand : IRequest<SearchDto>
	{
		public List<Interest> Interests { get; set; }
		public List<Zip>? Zips { get; set; }

		public SearchCommand(List<Interest> interests, List<Zip>? zips)
		{
			Interests = interests;
			Zips = zips;
		}
	}

	public record SearchDto
	{
		public List<User>? Results { get; set; }
	}
}
