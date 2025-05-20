using MAVI.Application.DTOs;
using MAVI.Domain.Interfaces.Repositories;
using MAVI.Domain.Models.Post;
using MediatR;

namespace MAVI.Application.Features.Posts.Commands;

public record CreatePostCommand(PostModelPost Post) : IRequest<int>;
public class CreatePostHandler(IPostRepository repository) : IRequestHandler<CreatePostCommand, int>
{
    public async Task<int> Handle(CreatePostCommand request, CancellationToken cancellationToken)
    {
        var postDto = request.Post;

        if (string.IsNullOrWhiteSpace(postDto.Username))
            throw new ArgumentException("Username is required.");

        if (string.IsNullOrWhiteSpace(postDto.Photo))
            throw new ArgumentException("Photo is required.");

        if (postDto.Caption?.Length > 200)
            throw new ArgumentException("Caption cannot exceed 200 characters.");

        var cleanedCaption = postDto.Caption?.Trim();
        var cleanedTag = postDto.Tag?.Trim().ToLowerInvariant();

        var time = string.IsNullOrWhiteSpace(postDto.Time.ToString())
            ? DateTime.UtcNow
            : postDto.Time;

        var post = new Post
        {
            UserPhoto = postDto.UserPhoto,
            Username = postDto.Username,
            Time = time,
            Photo = postDto.Photo,
            LikesPhotos = postDto.LikesPhotos,
            LikedBy = postDto.LikedBy,
            Caption = cleanedCaption ?? string.Empty,
            Tag = cleanedTag ?? string.Empty,
            CommentsText = postDto.CommentsText
        };

        await repository.AddAsync(post, cancellationToken);
        await repository.SaveChangesAsync(cancellationToken);
        return post.Id;
    }
}