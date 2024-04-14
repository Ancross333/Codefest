using Api.Commands;
using Microsoft.AspNetCore.Mvc;
using MediatR;
using Api.Requests;

namespace Api.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class MessagesController : ControllerBase
	{
		private readonly IMediator _mediator;

		public MessagesController(IMediator mediator)
		{
			_mediator = mediator;
		}

		[HttpGet]
		[Route("getMessages/{senderId}/{receiverId}/{oldestMessageId}")]
		public async Task<ActionResult> GetMessages([FromRoute] int senderId, [FromRoute] int receiverId, [FromRoute] int oldestMessageId)
		{
			var cmd = new RetreiveMessagesCommand(senderId, receiverId, oldestMessageId);
			var data = await _mediator.Send(cmd);

			return Ok(data);
		}

		[HttpGet]
		[Route("getConversations/{userId}")]
		public async Task<ActionResult> GetConversations(int userId)
		{
			var cmd = new RetreiveConversationsCommand(userId);
			var data = await _mediator.Send(cmd);

			return Ok(data);
		}

		[HttpPost]
		[Route("add")]
		public async Task<ActionResult> AddMessage(AddMessageRequest request)
		{
			var cmd = new AddMessageCommand(request.SenderId, request.ReceiverId, request.CreatedAt, request.Content);
			var data = await _mediator.Send(cmd);

			return StatusCode(201, data);
		}
	}
}
