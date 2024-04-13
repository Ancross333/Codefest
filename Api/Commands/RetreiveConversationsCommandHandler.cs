using Domain.Interfaces;
using Domain.Message;
using MediatR;

namespace Api.Commands
{
	public class RetreiveConversationsCommandHandler :
		IRequestHandler<RetreiveConversationsCommand, RetreiveConversationsDto>
	{
		private readonly IMessagesRepository _repository;

		public RetreiveConversationsCommandHandler(IMessagesRepository repository)
		{
			_repository = repository;
		}
		public async Task<RetreiveConversationsDto> Handle(RetreiveConversationsCommand request, CancellationToken cancellationToken)
		{
			ArgumentNullException.ThrowIfNull(request);

			return await HandleInternalAsync(request, cancellationToken);
		}

		public async Task<RetreiveConversationsDto> HandleInternalAsync(RetreiveConversationsCommand request, CancellationToken cancellationToken)
		{
			List<Conversation> conversations = await _repository.GetConversations(request.UserId);

			return new RetreiveConversationsDto() {
				Conversations = conversations
			};
		}
	}
}
