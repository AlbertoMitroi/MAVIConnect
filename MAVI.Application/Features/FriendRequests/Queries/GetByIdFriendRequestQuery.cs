using MAVI.Application.DTOs;
using MAVI.Domain.Interfaces.Repositories;
using MediatR;

namespace MAVI.Application.Features.FriendRequests.Queries
{
    public record GetByIdFriendRequestQuery(int Id) : IRequest<FriendRequestDto>;

    public class GetByIdFriendRequestHandler(IFriendRequestRepository repository) : IRequestHandler<GetByIdFriendRequestQuery, FriendRequestDto>
    {
        public async Task<FriendRequestDto> Handle(GetByIdFriendRequestQuery request, CancellationToken cancellationToken)
        {
            var friendRequest = await repository.GetByIdAsync(request.Id, cancellationToken);

            if (friendRequest == null)
            {
                throw new KeyNotFoundException($"Friend request with ID {request.Id} was not found.");
            }

            return new FriendRequestDto
            {
                Id = friendRequest.Id,
                Name = friendRequest.Name,
                Img = friendRequest.Img,
                Mutual = friendRequest.Mutual,
            };
        }
    }
}
