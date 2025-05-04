using MAVI.Domain.Models.Post;
using System.Runtime.CompilerServices;

namespace MAVI.Domain.Interfaces.Repositories
{
    public interface IPostRepository
    {
        Task<Post?> GetByIdAsync(int id, CancellationToken cancellationToken);
        Task<List<Post>> GetAllAsync(CancellationToken cancellationToken);
        Task AddAsync(Post post, CancellationToken cancellationToken);
        void Update(Post post);
        Task DeleteAsync(int id, CancellationToken cancellationToken);
        Task SaveChangesAsync(CancellationToken cancellationToken);
    }
}
