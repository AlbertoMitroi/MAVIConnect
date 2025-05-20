using System;
using MAVI.Application.DTOs;
using MAVI.Application.Features.Posts.Commands;
using MAVI.Domain.Interfaces.Repositories;
using MAVI.Domain.Models.Post;
using Moq;

namespace MAVI.Application.UnitTests.Features.Posts.Comands;

[TestClass]
public class UpdatePostHandlerTests
{
    private Mock<IPostRepository> _repositoryMock = null!;
    private UpdatePostHandler _handler = null!;

    [TestInitialize]
    public void Setup()
    {
        _repositoryMock = new Mock<IPostRepository>();
        _handler = new UpdatePostHandler(_repositoryMock.Object);
    }

    [TestMethod]
    public async Task Handle_ShouldReturnTrue_WhenPostExists()
    {
        // Arrange
        var dto = new PostDto { Id = 1, Caption = "New Caption", Tag = "#updated" };
        var post = new Post();

        _repositoryMock.Setup(r => r.GetByIdAsync(1, It.IsAny<CancellationToken>()))
                       .ReturnsAsync(post);

        _repositoryMock.Setup(r => r.SaveChangesAsync(It.IsAny<CancellationToken>()))
                       .Returns(Task.CompletedTask);

        var command = new UpdatePostCommand(dto);

        // Act
        var result = await _handler.Handle(command, CancellationToken.None);

        // Assert
        Assert.IsTrue(result);
        _repositoryMock.Verify(r => r.Update(post), Times.Once);
        _repositoryMock.Verify(r => r.SaveChangesAsync(It.IsAny<CancellationToken>()), Times.Once);
    }

    [TestMethod]
    public async Task Handle_ShouldReturnFalse_WhenPostNotFound()
    {
        // Arrange
        var dto = new PostDto { Id = 99, Caption = "Test", Tag = "#tag" };
        _repositoryMock.Setup(r => r.GetByIdAsync(99, It.IsAny<CancellationToken>()))
                       .ReturnsAsync((Post?)null);

        var command = new UpdatePostCommand(dto);

        // Act
        var result = await _handler.Handle(command, CancellationToken.None);

        // Assert
        Assert.IsFalse(result);
        _repositoryMock.Verify(r => r.Update(It.IsAny<Post>()), Times.Never);
    }

    [TestMethod]
    public async Task Handle_ShouldThrow_WhenPostDtoIsNull()
    {
        // Arrange
        var command = new UpdatePostCommand(null!);

        // Act & Assert
        await Assert.ThrowsExceptionAsync<ArgumentNullException>(async () =>
        {
            await _handler.Handle(command, CancellationToken.None);
        });
    }

    [TestMethod]
    public async Task Handle_ShouldThrow_WhenPostIdIsInvalid()
    {
        // Arrange
        var dto = new PostDto { Id = 0, Caption = "Test", Tag = "#tag" };
        var command = new UpdatePostCommand(dto);

        // Act & Assert
        await Assert.ThrowsExceptionAsync<ArgumentException>(async () =>
        {
            await _handler.Handle(command, CancellationToken.None);
        });
    }
}