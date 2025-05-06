using MAVI.Application.DTOs;
using MAVI.Application.Features.FriendRequests.Commands;
using MAVI.Application.Features.FriendRequests.Queries;
using Microsoft.AspNetCore.Mvc;
using MediatR;

namespace MAVI.API.Controllers.FriendRequests
{
    [ApiController]
    [Route("api/[controller]")]
    public class FriendRequestsController(IMediator mediator) : ControllerBase
    {

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var friendRequests = await mediator.Send(new GetAllFriendRequestsQuery());
            return Ok(friendRequests);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var friendRequest = await mediator.Send(new GetByIdFriendRequestQuery(id));

            if (friendRequest == null)
            {
                return NotFound();
            }

            return Ok(friendRequest);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] PostModelFriendRequest friendRequestDto)
        {
            var id = await mediator.Send(new CreateFriendRequestCommand(friendRequestDto));
            return CreatedAtAction(nameof(Get), new { id }, friendRequestDto);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var success = await mediator.Send(new DeleteFriendRequestCommand(id));
            
            if (!success)
            {
                return NotFound();
            }
            else
            {
                return Ok();
            }
        }
    }
}
