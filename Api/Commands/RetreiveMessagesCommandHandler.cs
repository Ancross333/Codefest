using Infrastructure.Repos;
using MediatR;

namespace Api.Commands
{
	public class RetreiveMessagesCommandHandler : IRequestHandler<RetreiveMessagesCommand, RetreiveMessagesDto>
	{
		private readonly MessagesRepository _repository;

		public RetreiveMessagesCommandHandler(MessagesRepository repository)
		{
			_repository = repository;
		}

		public Task<RetreiveMessagesDto> Handle(RetreiveMessagesCommand request, CancellationToken cancellationToken)
		{
			ArgumentNullException.ThrowIfNull(request);

			return HandleInternalAsync(request, cancellationToken);
		}

		private Task<RetreiveMessagesDto> HandleInternalAsync(RetreiveMessagesCommand request, CancellationToken cancellationToken)
		{

		}
	}
}
