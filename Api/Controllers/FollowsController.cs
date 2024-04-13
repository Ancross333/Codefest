using Api.Commands;
using Api.Requests;
using MediatR;
using Microsoft.AspNetCore.Mvc;
namespace Api.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class FollowsController : ControllerBase
	{
		private readonly IMediator _mediator;

		public FollowsController(IMediator mediator)
		{
			_mediator = mediator;
		}

		[HttpPost]
		[Route("addfollow")]
		public async Task<ActionResult> AddFollow(AddFollowRequest request)
		{
			var cmd = new AddFollowCommand(request.FollowerId, request.FolloweeId);
			var data = await _mediator.Send(cmd);

			return StatusCode(201, data);
		}
	}
}
