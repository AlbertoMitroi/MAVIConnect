using MAVI.Application.DTOs;
using MAVI.Domain.Interfaces.Repositories;
using MAVI.Domain.Models.Post;
using MediatR;

namespace MAVI.Application.Features.Posts.Commands
{
    public record CreatePostCommand(PostModelPost Post) : IRequest<int>;

    public class CreatePostHandler(IPostRepository repository) : IRequestHandler<CreatePostCommand, int>
    {
        public async Task<int> Handle(CreatePostCommand request, CancellationToken cancellationToken)
        {
            var post = new Post {
                UserPhoto = request.Post.UserPhoto,
                Username = request.Post.Username,
                Time = request.Post.Time,
                Photo = request.Post.Photo,
                LikesPhotos = request.Post.LikesPhotos,
                LikedBy = request.Post.LikedBy,
                Caption = request.Post.Caption,
                Tag = request.Post.Tag,
                CommentsText = request.Post.CommentsText };
            
            await repository.AddAsync(post, cancellationToken);
            await repository.SaveChangesAsync(cancellationToken);
            return post.Id;
        }
    }
}
