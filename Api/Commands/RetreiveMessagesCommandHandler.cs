using Infrastructure.Repos;
using MediatR;
using Domain.Message;
using Domain.Interfaces;

namespace Api.Commands
{
	public class RetreiveMessagesCommandHandler : IRequestHandler<RetreiveMessagesCommand, RetreiveMessagesDto>
	{
		private readonly IMessagesRepository _repository;

		public RetreiveMessagesCommandHandler(IMessagesRepository repository)
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
