using Domain.Interfaces;
using MediatR;
using Domain.User;
using Domain.Values;

namespace Api.Commands
{
	public class SearchCommandHandler : IRequestHandler<SearchCommand, SearchDto>
	{
		private readonly IUserRepository _userRepository;
		private readonly IValuesRepository _valuesRepository;

		public SearchCommandHandler(IUserRepository userRepository, IValuesRepository valuesRepository)
		{
			_userRepository = userRepository;
			_valuesRepository = valuesRepository;
		}
		public async Task<SearchDto> Handle(SearchCommand request, CancellationToken cancellationToken)
		{
			ArgumentNullException.ThrowIfNull(request);

			return await HandleInternalAsync(request, cancellationToken);
		}

		private async Task<SearchDto> HandleInternalAsync(SearchCommand request, CancellationToken cancellationToken)
		{
			List<User>? users = _userRepository.Search(request.Interests, request.Zips);

			List<SearchResult>? result = new();
			foreach (User user in users)
			{
				List<Interest> interests = _valuesRepository.GetValues(user.Id);
				result.Add(new SearchResult(user.Id, user.FirstName, user.LastName, user.ProfilePicture, interests, user.Zip));
			}

			return new SearchDto()
			{
				Results = result
			};
		}
	}
}
