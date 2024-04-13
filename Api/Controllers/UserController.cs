using Api.Requests;
using Microsoft.AspNetCore.Mvc;
using Api.Commands;
using MediatR;

namespace Api.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class UserController : ControllerBase
	{
		private readonly IMediator _mediator;

		public UserController(IMediator mediator)
		{
			_mediator = mediator;
		}
		[HttpPost]
		[Route("create")]
		public async Task<ActionResult> CreateUser(AddUserRequest request)
		{
			var cmd = new AddUserCommand(request.Email, request.Password, request.CompanyName, 
				request.FirstName, request.LastName, request.Zip, request.AccountType, 
				request.Values, request.ProfilePicture);
			var data = await _mediator.Send(cmd);

			return StatusCode(201, data);
		}
	}
}
