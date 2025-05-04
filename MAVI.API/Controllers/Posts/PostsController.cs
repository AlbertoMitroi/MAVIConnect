using MAVI.Application.DTOs;
using MAVI.Application.Features.Posts.Commands;
using MAVI.Application.Features.Posts.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace MAVI.API.Controllers.Posts
{
    [ApiController]
    [Route("api/[controller]")]
    public class PostController(IMediator mediator) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var posts = await mediator.Send(new GetAllPostsQuery());
            return Ok(posts);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var post = await mediator.Send(new GetByIdPostQuery(id));

            if (post == null)
            {
                return NotFound();
            }

            return Ok(post);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] PostModelPost postDto)
        {
            var id = await mediator.Send(new CreatePostCommand(postDto));
            return CreatedAtAction(nameof(Get), new { id }, postDto);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] PostDto postDto)
        {
            var success = await mediator.Send(new UpdatePostCommand(postDto));

            if (!success)
            {
                return NotFound();
            }

            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var success = await mediator.Send(new DeletePostCommand(id));

            if (!success)
            {
                return NotFound();
            }

            return Ok();
        }
    }
}
