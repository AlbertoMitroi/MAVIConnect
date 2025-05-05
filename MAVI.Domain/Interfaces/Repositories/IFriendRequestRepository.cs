using MAVI.Domain.Models.FriendRequest;

namespace MAVI.Domain.Interfaces.Repositories
{
    public interface IFriendRequestRepository
    {
        Task<FriendRequest?> GetByIdAsync(int id, CancellationToken cancellationToken);
        Task<List<FriendRequest>> GetAllAsync(CancellationToken cancellationToken);
        Task AddAsync(FriendRequest request, CancellationToken cancellationTokenc);
        Task DeleteAsync(int id, CancellationToken cancellationToken);
        Task SaveChangesAsync(CancellationToken cancellationToken);
    }
}
