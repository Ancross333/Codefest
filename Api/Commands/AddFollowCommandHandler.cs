using Domain.Follow;
using Domain.Interfaces;
using MediatR;

namespace Api.Commands
{
	public class AddFollowCommandHandler : IRequestHandler<AddFollowCommand, AddFollowDto>
	{
		private readonly IFollowsRepository _repository;

		public AddFollowCommandHandler(IFollowsRepository repository)
		{
			_repository = repository;
		}
		public async Task<AddFollowDto> Handle(AddFollowCommand request, CancellationToken cancellationToken)
		{
			ArgumentNullException.ThrowIfNull(request);

			return await HandleTaskAsync(request, cancellationToken);
		}

		public async Task<AddFollowDto> HandleTaskAsync(AddFollowCommand request, CancellationToken cancellationToken)
		{
			Follow follow = new(request.FollowerId, request.FolloweeId);

			await _repository.AddAsync(follow);

			return new AddFollowDto()
			{
				FolloweeId = follow.FolloweeId,
				FollowerId = follow.FollowerId
			};
		}
	}
}
