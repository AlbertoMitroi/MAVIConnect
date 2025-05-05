using MAVI.Domain.Interfaces.Repositories;
using MediatR;

namespace MAVI.Application.Features.FriendRequests.Commands
{
    public record DeleteFriendRequestCommand(int FriendRequestId) : IRequest<bool>;
    public class DeleteFriendRequestCommandHandler(IFriendRequestRepository repository) : IRequestHandler<DeleteFriendRequestCommand, bool>
    {
        public async Task<bool> Handle(DeleteFriendRequestCommand request, CancellationToken cancellationToken)
        {
            var friendRequest = await repository.GetByIdAsync(request.FriendRequestId, cancellationToken);
            if (friendRequest == null)
            {
                return false;
            }

            await repository.DeleteAsync(request.FriendRequestId, cancellationToken);
            await repository.SaveChangesAsync(cancellationToken);
            return true;
        }
    }
}
