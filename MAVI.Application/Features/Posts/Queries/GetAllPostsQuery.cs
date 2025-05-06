using MAVI.Application.DTOs;
using MAVI.Domain.Interfaces.Repositories;
using MediatR;

namespace MAVI.Application.Features.Posts.Queries
{
    public record GetAllPostsQuery : IRequest<List<PostDto>>;

    public class GetAllPostsHandler(IPostRepository repository) : IRequestHandler<GetAllPostsQuery, List<PostDto>>
    {
        public async Task<List<PostDto>> Handle(GetAllPostsQuery request, CancellationToken cancellationToken)
        {
            var posts = await repository.GetAllAsync(cancellationToken);
            return posts
            .OrderByDescending(p => p.Time)
            .ThenByDescending(p => p.Id)
            .Select(p => new PostDto
            {
                Id = p.Id,
                UserPhoto = p.UserPhoto,
                Username = p.Username,
                Time = p.Time,
                Photo = p.Photo,
                LikesPhotos = p.LikesPhotos,
                LikedBy = p.LikedBy,
                Caption = p.Caption,
                Tag = p.Tag,
                CommentsText = p.CommentsText
            }).ToList();
        }
    }
}
