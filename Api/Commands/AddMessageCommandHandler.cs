using Domain.Interfaces;
using Domain.Message;
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

		private async Task<AddMessageDto> HandleInternalAsync(AddMessageCommand request, CancellationToken cancellationToken)
		{
			Message message = new(request.SenderId, request.ReceiverId, request.CreatedAt, request.Content);
			await _repository.AddAsync(message);
			await _repository.SaveChangesAsync();

			return new AddMessageDto()
			{
				MessageId = message.Id
			};
		}
	}
}

