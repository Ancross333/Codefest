using Domain.Interfaces;
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
		public Task<RetreiveConversationsDto> Handle(RetreiveConversationsCommand request, CancellationToken cancellationToken)
		{
			throw new NotImplementedException();
		}

		public Task<RetreiveConversationsDto> HandleInternalAsync(RetreiveConversationsCommand request, CancellationToken cancellationToken)
		{
			throw new NotImplementedException();
		}
	}
}
