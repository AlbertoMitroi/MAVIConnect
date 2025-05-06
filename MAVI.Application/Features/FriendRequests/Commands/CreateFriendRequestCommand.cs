using MAVI.Application.DTOs;
using MAVI.Domain.Interfaces.Repositories;
using MAVI.Domain.Models.FriendRequest;
using MediatR;

namespace MAVI.Application.Features.FriendRequests.Commands
{
    public record CreateFriendRequestCommand(PostModelFriendRequest FriendRequest) : IRequest<int>;
    public class CreateFriendRequestCommandHandler(IFriendRequestRepository repository) : IRequestHandler<CreateFriendRequestCommand, int>
    {
        public async Task<int> Handle(CreateFriendRequestCommand request, CancellationToken cancellationToken)
        {
            var friendRequest = new FriendRequest
            {
                Img = request.FriendRequest.Img,
                Name = request.FriendRequest.Name,
                Mutual = request.FriendRequest.Mutual,
            };
            await repository.AddAsync(friendRequest, cancellationToken);
            await repository.SaveChangesAsync(cancellationToken);
            return friendRequest.Id;
        }
    }
}
