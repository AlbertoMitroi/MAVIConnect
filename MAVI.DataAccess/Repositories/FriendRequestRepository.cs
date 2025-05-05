using Microsoft.EntityFrameworkCore;
using MAVI.Domain.Interfaces.Repositories;
using MAVI.Domain.Models.FriendRequest;

namespace MAVI.DataAccess.Repositories
{
    public class FriendRequestRepository(DataDbContext context) : IFriendRequestRepository
    {
        public async Task AddAsync(FriendRequest request, CancellationToken cancellationToken)
        {
            await context.FriendRequests.AddAsync(request, cancellationToken);
            await context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id, CancellationToken cancellationToken)
        {
            var requests = await context.FriendRequests.FindAsync(new object[] { id }, cancellationToken);
            if (requests != null)
            {
                context.FriendRequests.Remove(requests);
            }
        }

        public async Task<List<FriendRequest>> GetAllAsync(CancellationToken cancellationToken)
        {
            return await context.FriendRequests.ToListAsync(cancellationToken);
        }

        public async Task<FriendRequest?> GetByIdAsync(int id, CancellationToken cancellationToken)
        {
            return await context.FriendRequests.FindAsync([id], cancellationToken);
        }
        public async Task SaveChangesAsync(CancellationToken cancellationToken)
        {
            await context.SaveChangesAsync(cancellationToken);
        }
    }
}
