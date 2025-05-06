using MAVI.Domain.Models.FriendRequest;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MAVI.DataAccess.Configuration
{
    public class FriendRequestConfiguration : IEntityTypeConfiguration<FriendRequest>
    {
        public void Configure(EntityTypeBuilder<FriendRequest> builder)
        {
            builder.HasKey(f => f.Id);

            builder.Property(f => f.Img).IsRequired();
            builder.Property(f => f.Name).IsRequired();
            builder.Property(f => f.Mutual).IsRequired();
            builder.Property(f => f.Mutual).HasDefaultValue(0);

            builder.HasData(
                new FriendRequest
                {
                    Id = 1,
                    Img = "https://robohash.org/user1?set=set4",
                    Name = "john_doe",
                    Mutual = 5
                },
                new FriendRequest
                {
                    Id = 2,
                    Img = "https://robohash.org/user2?set=set4",
                    Name = "jane_smith",
                    Mutual = 3
                },
                new FriendRequest
                {
                    Id = 3,
                    Img = "https://robohash.org/user3?set=set4",
                    Name = "michael23",
                    Mutual = 15
                }
            );
        }
    }
}
