using MAVI.Application.DTOs;
using MAVI.Domain.Interfaces.Repositories;
using MediatR;

namespace MAVI.Application.Features.Posts.Commands
{
    public record UpdatePostCommand(PostDto Post) : IRequest<bool>;

    public class UpdatePostHandler(IPostRepository repository) : IRequestHandler<UpdatePostCommand, bool>
    {
        public async Task<bool> Handle(UpdatePostCommand request, CancellationToken cancellationToken)
        {
            var existingPost = await repository.GetByIdAsync(request.Post.Id, cancellationToken);
            if (existingPost == null)
                return false;

            existingPost.UpdateCaption(request.Post.Caption);
            existingPost.UpdateTag(request.Post.Tag);

            repository.Update(existingPost);
            await repository.SaveChangesAsync(cancellationToken);
            return true;
        }
    }
}