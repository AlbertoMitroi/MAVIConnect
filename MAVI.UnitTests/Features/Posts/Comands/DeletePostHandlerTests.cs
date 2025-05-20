using System;
using MAVI.Application.Features.Posts.Commands;
using MAVI.Domain.Interfaces.Repositories;
using MAVI.Domain.Models.Post;
using Moq;

namespace MAVI.Application.UnitTests.Features.Posts.Comands;
 [TestClass]
    public class DeletePostHandlerTests
    {
        private Mock<IPostRepository> _repositoryMock = null!;
        private DeletePostHandler _handler = null!;

        [TestInitialize]
        public void Setup()
        {
            _repositoryMock = new Mock<IPostRepository>();
            _handler = new DeletePostHandler(_repositoryMock.Object);
        }

        [TestMethod]
        public async Task Handle_ShouldReturnTrue_WhenPostExists()
        {
            // Arrange
            var post = new Post { Id = 1 };
            _repositoryMock.Setup(r => r.GetByIdAsync(1, It.IsAny<CancellationToken>()))
                           .ReturnsAsync(post);

            _repositoryMock.Setup(r => r.DeleteAsync(1, It.IsAny<CancellationToken>()))
                           .Returns(Task.CompletedTask);

            _repositoryMock.Setup(r => r.SaveChangesAsync(It.IsAny<CancellationToken>()))
                           .Returns(Task.CompletedTask);

            var command = new DeletePostCommand(1);

            // Act
            var result = await _handler.Handle(command, CancellationToken.None);

            // Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public async Task Handle_ShouldReturnFalse_WhenPostDoesNotExist()
        {
            // Arrange
            _repositoryMock.Setup(r => r.GetByIdAsync(It.IsAny<int>(), It.IsAny<CancellationToken>()))
                           .ReturnsAsync((Post?)null);

            var command = new DeletePostCommand(99);

            // Act
            var result = await _handler.Handle(command, CancellationToken.None);

            // Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public async Task Handle_ShouldCallDeleteAndSave_WhenPostExists()
        {
            // Arrange
            var post = new Post { Id = 2 };

            _repositoryMock.Setup(r => r.GetByIdAsync(2, It.IsAny<CancellationToken>()))
                           .ReturnsAsync(post);

            _repositoryMock.Setup(r => r.DeleteAsync(2, It.IsAny<CancellationToken>()))
                           .Returns(Task.CompletedTask);

            _repositoryMock.Setup(r => r.SaveChangesAsync(It.IsAny<CancellationToken>()))
                           .Returns(Task.CompletedTask);

            var command = new DeletePostCommand(2);

            // Act
            await _handler.Handle(command, CancellationToken.None);

            // Assert
            _repositoryMock.Verify(r => r.DeleteAsync(2, It.IsAny<CancellationToken>()), Times.Once);
            _repositoryMock.Verify(r => r.SaveChangesAsync(It.IsAny<CancellationToken>()), Times.Once);
        }

        [TestMethod]
        public async Task Handle_ShouldThrow_WhenPostIdIsInvalid()
        {
            // Arrange
            var command = new DeletePostCommand(0);

            // Act & Assert
            await Assert.ThrowsExceptionAsync<ArgumentException>(async () =>
            {
                await _handler.Handle(command, CancellationToken.None);
            });
        }
    }