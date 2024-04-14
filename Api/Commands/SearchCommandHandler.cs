using Domain.Interfaces;
using MediatR;
using Domain.User;

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

			return new SearchDto()
			{
				Results = users
			};
		}
	}
}
