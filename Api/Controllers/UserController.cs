using Api.Requests;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class UserController : ControllerBase
	{
		[HttpPost]
		[Route("create")]
		public ActionResult CreateUser(AddUserRequest request)
		{
			var cmd = new AddUserCommand();
		}
	}
}
