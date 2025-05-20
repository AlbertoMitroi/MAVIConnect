using MAVI.Application.Features.FriendRequests.Queries;
using MAVI.Domain.Interfaces.Repositories;
using MAVI.Domain.Models.FriendRequest;
using Moq;

namespace MAVI.Application.UnitTests.Features.FriendRequests.Queries
{
   public sealed class GetAllFriendRequestsQueryTest
    {
        [TestClass]
        public class GetAllFriendRequestsQueryHandlerTests
        {
            [TestMethod]
            public async Task Handle_Should_Return_Ordered_FriendRequestDtos()
            {
                // Arrange
                var mockRepo = new Mock<IFriendRequestRepository>();
                var cancellationToken = CancellationToken.None;

                var friendRequests = new List<FriendRequest>
            {
                new FriendRequest { Id = 1, Img = "img1.png", Name = "Alice", Mutual = 2 },
                new FriendRequest { Id = 3, Img = "img3.png", Name = "Charlie", Mutual = 5 },
                new FriendRequest { Id = 2, Img = "img2.png", Name = "Bob", Mutual = 3 }
            };

                mockRepo.Setup(r => r.GetAllAsync(cancellationToken))
                        .ReturnsAsync(friendRequests);

                var handler = new GetAllFriendRequestsQueryHandler(mockRepo.Object);

                var query = new GetAllFriendRequestsQuery();

                // Act
                var result = await handler.Handle(query, cancellationToken);

                // Assert
                Assert.AreEqual(3, result.Count);
                Assert.AreEqual(3, result[0].Id);
                Assert.AreEqual("Charlie", result[0].Name);

                Assert.AreEqual(2, result[1].Id);
                Assert.AreEqual("Bob", result[1].Name);

                Assert.AreEqual(1, result[2].Id);
                Assert.AreEqual("Alice", result[2].Name);

                mockRepo.Verify(r => r.GetAllAsync(cancellationToken), Times.Once);
            }
        }
    }
}
