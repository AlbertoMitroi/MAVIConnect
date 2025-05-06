using MAVI.Application.DTOs;
using MAVI.Domain.Interfaces.Repositories;
using MediatR;

namespace MAVI.Application.Features.FriendRequests.Queries
{
    public record GetAllFriendRequestsQuery : IRequest<List<FriendRequestDto>>;
    public class GetAllFriendRequestsQueryHandler(IFriendRequestRepository repository) : IRequestHandler<GetAllFriendRequestsQuery, List<FriendRequestDto>>
    {
        public async Task<List<FriendRequestDto>> Handle(GetAllFriendRequestsQuery request, CancellationToken cancellationToken)
        {
            var requests = await repository.GetAllAsync(cancellationToken);

            return requests.Select(r => new FriendRequestDto
            {
               Id = r.Id,
               Img = r.Img,
               Name = r.Name,
               Mutual = r.Mutual
            }).ToList();
        }
    }
}
