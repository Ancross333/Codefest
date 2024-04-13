using Domain.Interfaces;
using MediatR;

namespace Api.Commands
{
	public class AddMessageCommandHandler : IRequestHandler<AddMessageCommand, AddMessageDto>
	{
		private readonly IMessagesRepository _repository;

		public AddMessageCommandHandler(IMessagesRepository repository)
		{
			_repository = repository;
		}
		public async Task<AddMessageDto> Handle(AddMessageCommand request, CancellationToken cancellationToken)
		{
			ArgumentNullException.ThrowIfNull(request);

			return await HandleInternalAsync(request, cancellationToken);
		}

		private Task<AddMessageDto> HandleInternalAsync(AddMessageCommand request, CancellationToken cancellationToken)
		{

		}
	}
}
}
