using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MAVI.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Posts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserPhoto = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Time = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Photo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LikesPhotos = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LikedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Caption = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Tag = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CommentsText = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Posts", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Posts",
                columns: new[] { "Id", "Caption", "CommentsText", "LikedBy", "LikesPhotos", "Photo", "Tag", "Time", "UserPhoto", "Username" },
                values: new object[,]
                {
                    { 1, "Explorând orașul vechi.", "Super poza!", "alice", "[]", "https://picsum.photos/seed/post1/600/400", "urban", new DateTime(2025, 5, 4, 21, 42, 10, 386, DateTimeKind.Utc).AddTicks(1514), "https://robohash.org/user1?set=set4", "john_doe" },
                    { 2, "Vacanță în natură.", "Ce peisaj!", "bob", "[]", "https://picsum.photos/seed/post2/600/400", "nature", new DateTime(2025, 5, 4, 21, 42, 10, 386, DateTimeKind.Utc).AddTicks(2360), "https://robohash.org/user2?set=set4", "jane_smith" },
                    { 3, "Cafeaua de dimineață contează.", "Și eu ador cafeaua!", "lucy", "[]", "https://picsum.photos/seed/post3/600/400", "coffee", new DateTime(2025, 5, 4, 21, 42, 10, 386, DateTimeKind.Utc).AddTicks(2362), "https://robohash.org/user3?set=set4", "michael23" },
                    { 4, "Am descoperit un colț liniștit.", "Unde este locul ăsta?", "tom", "[]", "https://picsum.photos/seed/post4/600/400", "hiddenplaces", new DateTime(2025, 5, 4, 21, 42, 10, 386, DateTimeKind.Utc).AddTicks(2364), "https://robohash.org/user4?set=set4", "clara_l" },
                    { 5, "Zâmbetul face ziua mai bună 😊", "Exact ce aveam nevoie azi!", "sara", "[]", "https://picsum.photos/seed/post5/600/400", "smile", new DateTime(2025, 5, 4, 21, 42, 10, 386, DateTimeKind.Utc).AddTicks(2434), "https://robohash.org/user5?set=set4", "dani_k" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Posts");
        }
    }
}
