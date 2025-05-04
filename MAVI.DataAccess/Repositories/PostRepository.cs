using MAVI.Domain.Interfaces.Repositories;
using MAVI.Domain.Models.Post;
using Microsoft.EntityFrameworkCore;

namespace MAVI.DataAccess.Repositories
{
    public class PostRepository(DataDbContext context) : IPostRepository
    {

        public async Task AddAsync(Post post, CancellationToken cancellationToken)
        {
            await context.Posts.AddAsync(post, cancellationToken);
        }

        public async Task DeleteAsync(int id, CancellationToken cancellationToken)
        {
            var post = await context.Posts.FindAsync(new object[] { id }, cancellationToken);
            if (post != null)
            {
                context.Posts.Remove(post);
            }
        }

        public async Task<List<Post>> GetAllAsync(CancellationToken cancellationToken)
        {
            return await context.Posts.ToListAsync(cancellationToken);
        }

        public async Task<Post?> GetByIdAsync(int id, CancellationToken cancellationToken)
        {
            return await context.Posts.FindAsync([id], cancellationToken);
        }

        public async Task<List<Post>> GetPostsByUsernameAsync(string username, CancellationToken cancellationToken)
        {
            return await context.Posts
                .Where(p => p.Username == username)
                .ToListAsync(cancellationToken);
        }

        public void Update(Post post)
        {
            context.Posts.Update(post);
        }

        public async Task SaveChangesAsync(CancellationToken cancellationToken)
        {
            await context.SaveChangesAsync(cancellationToken);
        }
    }
}
