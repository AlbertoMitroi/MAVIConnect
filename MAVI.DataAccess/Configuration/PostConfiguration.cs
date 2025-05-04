using MAVI.Domain.Models.Post;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace MAVI.DataAccess.Configuration
{
    class PostConfiguration : IEntityTypeConfiguration<Post>
    {
        public void Configure(EntityTypeBuilder<Post> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.UserPhoto).IsRequired();
            builder.Property(p => p.Username).IsRequired();
            builder.Property(p => p.Photo).IsRequired();
            builder.Property(p => p.Time).IsRequired();
            builder.Property(p => p.Caption).HasMaxLength(500);
            builder.Property(p => p.Tag).HasMaxLength(100);

            builder.HasData(
                new Post
                {
                    Id = 1,
                    UserPhoto = "https://robohash.org/user1?set=set4",
                    Username = "john_doe",
                    Photo = "https://picsum.photos/seed/post1/600/400",
                    Time = new DateTime(2024, 1, 1, 12, 0, 0, DateTimeKind.Utc),
                    Caption = "Explorând orașul vechi.",
                    Tag = "urban",
                    LikedBy = "alice",
                    CommentsText = "Super poza!"
                },
                new Post
                {
                    Id = 2,
                    UserPhoto = "https://robohash.org/user2?set=set4",
                    Username = "jane_smith",
                    Photo = "https://picsum.photos/seed/post2/600/400",
                    Time = new DateTime(2024, 1, 1, 12, 0, 0, DateTimeKind.Utc),
                    Caption = "Vacanță în natură.",
                    Tag = "nature",
                    LikedBy = "bob",
                    CommentsText = "Ce peisaj!"
                },
                new Post
                {
                    Id = 3,
                    UserPhoto = "https://robohash.org/user3?set=set4",
                    Username = "michael23",
                    Photo = "https://picsum.photos/seed/post3/600/400",
                    Time = new DateTime(2024, 1, 1, 12, 0, 0, DateTimeKind.Utc),
                    Caption = "Cafeaua de dimineață contează.",
                    Tag = "coffee",
                    LikedBy = "lucy",
                    CommentsText = "Și eu ador cafeaua!"
                },
                new Post
                {
                    Id = 4,
                    UserPhoto = "https://robohash.org/user4?set=set4",
                    Username = "clara_l",
                    Photo = "https://picsum.photos/seed/post4/600/400",
                    Time = new DateTime(2024, 1, 1, 12, 0, 0, DateTimeKind.Utc),
                    Caption = "Am descoperit un colț liniștit.",
                    Tag = "hiddenplaces",
                    LikedBy = "tom",
                    CommentsText = "Unde este locul ăsta?"
                },
                new Post
                {
                    Id = 5,
                    UserPhoto = "https://robohash.org/user5?set=set4",
                    Username = "dani_k",
                    Photo = "https://picsum.photos/seed/post5/600/400",
                    Time = new DateTime(2024, 1, 1, 12, 0, 0, DateTimeKind.Utc),
                    Caption = "Zâmbetul face ziua mai bună 😊",
                    Tag = "smile",
                    LikedBy = "sara",
                    CommentsText = "Exact ce aveam nevoie azi!"
                }
            );
        }
    }
}
