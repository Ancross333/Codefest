using MediatR;
using Api.Commands;
using Api.Requests;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PostController : ControllerBase
    {
        private readonly IMediator _mediator;

        public PostController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [Route("get/$UserId/$StartingPostId")]
        public async Task<ActionResult> GetPosts(int UserId, int StartingPostId)
        {
            var cmd = new RetrievePostsCommand(UserId, StartingPostId);
            var data = await _mediator.Send(cmd);
            return StatusCode(201, data);
        }
    }
}
