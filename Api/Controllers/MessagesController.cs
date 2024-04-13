﻿using Api.Commands;
using Microsoft.AspNetCore.Mvc;
using MediatR;

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
		[Route("get/$senderId/$receiverId/$oldestMessageId")]
		public async Task<ActionResult> GetMessages(int senderId, int receiverId, int oldestMessageId)
		{
			var cmd = new RetreiveMessagesCommand(senderId, receiverId, oldestMessageId);
			var data = await _mediator.Send(cmd);

			return StatusCode(201, data);
		}
	}
}
