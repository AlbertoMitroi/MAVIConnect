using MAVI.Application.DTOs;
using MAVI.Application.Features.FriendRequests.Commands;
using MAVI.Domain.Interfaces.Repositories;
using MAVI.Domain.Models.FriendRequest;
using Moq;

namespace MAVI.Application.UnitTests.Features.FriendRequests.Commands
{
    public sealed class CreateFriendRequestCommandHandlerTest
    {
        [TestClass]
        public class CreateFriendRequestCommandHandlerTests
        {
            [TestMethod]
            public async Task Handle_Should_Add_FriendRequest_And_Return_Id()
            {
                // Arrange
                var mockRepo = new Mock<IFriendRequestRepository>();
                var cancellationToken = CancellationToken.None;

                var friendRequest = new FriendRequest
                {
                    Id = 1,
                    Img = "img.png",
                    Name = "Test Name",
                    Mutual = 3
                };

                mockRepo.Setup(r => r.AddAsync(It.IsAny<FriendRequest>(), cancellationToken))
                        .Callback<FriendRequest, CancellationToken>((fr, _) => fr.Id = friendRequest.Id)
                        .Returns(Task.CompletedTask);

                mockRepo.Setup(r => r.SaveChangesAsync(cancellationToken))
                        .Returns(Task.CompletedTask);

                var handler = new CreateFriendRequestCommandHandler(mockRepo.Object);

                var command = new CreateFriendRequestCommand(new PostModelFriendRequest
                {
                    Img = friendRequest.Img,
                    Name = friendRequest.Name,
                    Mutual = friendRequest.Mutual
                });

                // Act
                var resultId = await handler.Handle(command, cancellationToken);

                // Assert
                Assert.AreEqual(1, resultId);
                mockRepo.Verify(r => r.AddAsync(It.IsAny<FriendRequest>(), cancellationToken), Times.Once);
                mockRepo.Verify(r => r.SaveChangesAsync(cancellationToken), Times.Once);
            }

            [TestMethod]
            public async Task Handle_Should_Throw_Exception_When_AddAsync_Fails()
            {
                // Arrange
                var mockRepo = new Mock<IFriendRequestRepository>();
                var cancellationToken = CancellationToken.None;

                mockRepo.Setup(r => r.AddAsync(It.IsAny<FriendRequest>(), cancellationToken))
                        .ThrowsAsync(new InvalidOperationException("Can't add friend!"));

                var handler = new CreateFriendRequestCommandHandler(mockRepo.Object);

                var command = new CreateFriendRequestCommand(new PostModelFriendRequest
                {
                    Img = "img.png",
                    Name = "Test Name",
                    Mutual = 2
                });

                // Act & Assert
                await Assert.ThrowsExceptionAsync<InvalidOperationException>(() => handler.Handle(command, cancellationToken));
            }
        }
    }
}
