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
		public List<SearchResult>? Results { get; set; }
	}

	public record SearchResult
	{
		public int UserId { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public ProfilePicture ProfilePicture { get; set; }
		public List<Interest>? Values { get; set; }
		public Zip Zip { get; set; }

		public SearchResult(int userId, string firstName, string lastName, ProfilePicture profilePicture, List<Interest>? values, Zip zip)
		{
			UserId = userId;
			FirstName = firstName;
			LastName = lastName;
			ProfilePicture = profilePicture;
			Values = values;
			Zip = zip;
		}
	}
}
