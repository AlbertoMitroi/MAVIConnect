using MAVI.Domain.Models.Post;
using Microsoft.EntityFrameworkCore;

namespace MAVI.DataAccess
{
    public class DataDbContext(DbContextOptions<DataDbContext> options) : DbContext(options)
    {
        public DbSet<Post> Posts => Set<Post>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(DataDbContext).Assembly);
            base.OnModelCreating(modelBuilder);
        }
    }
}
