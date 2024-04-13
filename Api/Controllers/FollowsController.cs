using Microsoft.AspNetCore.Mvc;
namespace Api.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class FollowsController : ControllerBase
	{
		[HttpPost]
		[Route("addfollow")]
		public ActionResult AddFollow()
		{

		}
	}
}
