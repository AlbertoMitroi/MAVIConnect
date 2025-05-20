using System;
using MAVI.Application.DTOs;
using MAVI.Application.Features.Posts.Commands;
using MAVI.Domain.Interfaces.Repositories;
using MAVI.Domain.Models.Post;
using Microsoft.IdentityModel.Tokens;
using Moq;

namespace MAVI.Application.UnitTests.Features.Posts.Comands;

[TestClass]
public class CreatePostHandlerTests
{
    private Mock<IPostRepository> _repositoryMock = null!;
    private CreatePostHandler _handler = null!;

    [TestInitialize]
    public void Setup()
    {
        _repositoryMock = new Mock<IPostRepository>();
        _handler = new CreatePostHandler(_repositoryMock.Object);
    }

    [TestMethod]
    public async Task Handle_ShouldReturnPostId_WhenPostIsValid()
    {
        // Arrange
        var expectedId = 123;
        Post? savedPost = null;

        _repositoryMock.Setup(r => r.AddAsync(It.IsAny<Post>(), It.IsAny<CancellationToken>()))
            .Callback<Post, CancellationToken>((p, ct) =>
            {
                p.Id = expectedId;
                savedPost = p;
            })
            .Returns(Task.CompletedTask);

        _repositoryMock.Setup(r => r.SaveChangesAsync(It.IsAny<CancellationToken>()))
            .Returns(Task.CompletedTask);

        var command = new CreatePostCommand(new PostModelPost
        {
            Username = "john_doe",
            Photo = "photo.jpg",
            Caption = "test caption",
            Tag = "tag123",
            Time = DateTime.UtcNow
        });

        // Act
        var result = await _handler.Handle(command, CancellationToken.None);

        // Assert
        Assert.AreEqual(expectedId, result);
    }

    [TestMethod]
    public async Task Handle_ShouldNormalizeCaptionAndTag()
    {
        // Arrange
        Post? savedPost = null;

        _repositoryMock.Setup(r => r.AddAsync(It.IsAny<Post>(), It.IsAny<CancellationToken>()))
            .Callback<Post, CancellationToken>((p, ct) => savedPost = p)
            .Returns(Task.CompletedTask);

        _repositoryMock.Setup(r => r.SaveChangesAsync(It.IsAny<CancellationToken>()))
            .Returns(Task.CompletedTask);

        var command = new CreatePostCommand(new PostModelPost
        {
            Username = "user",
            Photo = "photo.jpg",
            Caption = "   Hello World!   ",
            Tag = "  MyTag  ",
            Time = DateTime.UtcNow
        });

        // Act
        await _handler.Handle(command, CancellationToken.None);

        // Assert
        Assert.IsNotNull(savedPost);
        Assert.AreEqual("Hello World!", savedPost!.Caption);
        Assert.AreEqual("mytag", savedPost.Tag);
    }

    [TestMethod]
    public async Task Handle_ShouldThrow_WhenUsernameIsMissing()
    {
        // Arrange
        var command = new CreatePostCommand(new PostModelPost
        {
            Username = "",
            Photo = "photo.jpg",
            Time = DateTime.UtcNow
        });

        // Act & Assert
        await Assert.ThrowsExceptionAsync<ArgumentException>(async () =>
        {
            await _handler.Handle(command, CancellationToken.None);
        });
    }

    [TestMethod]
    public async Task Handle_ShouldThrow_WhenPhotoIsMissing()
    {
        // Arrange
        var command = new CreatePostCommand(new PostModelPost
        {
            Username = "john_doe",
            Photo = "",
            Time = DateTime.UtcNow
        });

        // Act & Assert
        await Assert.ThrowsExceptionAsync<ArgumentException>(async () =>
        {
            await _handler.Handle(command, CancellationToken.None);
        });
    }

    [TestMethod]
    public async Task Handle_ShouldThrow_WhenCaptionIsTooLong()
    {
        // Arrange
        var longCaption = new string('x', 201);

        var command = new CreatePostCommand(new PostModelPost
        {
            Username = "john_doe",
            Photo = "photo.jpg",
            Caption = longCaption,
            Time = DateTime.UtcNow
        });

        // Act & Assert
        await Assert.ThrowsExceptionAsync<ArgumentException>(async () =>
        {
            await _handler.Handle(command, CancellationToken.None);
        });
    }
}