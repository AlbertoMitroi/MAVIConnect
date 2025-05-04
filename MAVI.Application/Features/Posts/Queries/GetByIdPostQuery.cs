using MAVI.Application.DTOs;
using MAVI.Domain.Interfaces.Repositories;
using MediatR;

namespace MAVI.Application.Features.Posts.Queries
{
    public record GetByIdPostQuery(int Id) : IRequest<PostDto>;

    public class GetByIdPostHandler(IPostRepository repository) : IRequestHandler<GetByIdPostQuery, PostDto>
    {
        public async Task<PostDto> Handle(GetByIdPostQuery request, CancellationToken cancellationToken)
        {
            var post = await repository.GetByIdAsync(request.Id, cancellationToken);

            if (post == null)
            {
                throw new KeyNotFoundException($"Post with ID {request.Id} was not found.");
            }

            return new PostDto
            {
                Id = post.Id,
                UserPhoto = post.UserPhoto,
                Username = post.Username,
                Time = post.Time,
                Photo = post.Photo,
                LikesPhotos = post.LikesPhotos,
                LikedBy = post.LikedBy,
                Caption = post.Caption,
                Tag = post.Tag,
                CommentsText = post.CommentsText
            };
        }
    }
}
