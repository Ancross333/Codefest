using Infrastructure.Repos;
using MediatR;
using Domain.Message;

namespace Api.Commands
{
	public class RetreiveMessagesCommandHandler : IRequestHandler<RetreiveMessagesCommand, RetreiveMessagesDto>
	{
		private readonly MessagesRepository _repository;

		public RetreiveMessagesCommandHandler(MessagesRepository repository)
		{
			_repository = repository;
		}

		public async Task<RetreiveMessagesDto> Handle(RetreiveMessagesCommand request, CancellationToken cancellationToken)
		{
			ArgumentNullException.ThrowIfNull(request);

			return await HandleInternalAsync(request, cancellationToken);
		}

		private async Task<RetreiveMessagesDto> HandleInternalAsync(RetreiveMessagesCommand request, CancellationToken cancellationToken)
		{
			List<Message> messages = _repository.Get(request.SenderId, request.ReceiverId, request.OldestMessageId);

			return new RetreiveMessagesDto()
			{
				Messages = messages
			};
		}
	}
}
