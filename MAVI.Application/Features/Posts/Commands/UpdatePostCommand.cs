using MAVI.Application.DTOs;
using MAVI.Domain.Interfaces.Repositories;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace MAVI.Application.Features.Posts.Commands
{
    public record UpdatePostCommand(PostDto Post) : IRequest<bool>;

    public class UpdatePostHandler(IPostRepository repository) : IRequestHandler<UpdatePostCommand, bool>
    {
        public async Task<bool> Handle(UpdatePostCommand request, CancellationToken cancellationToken)
        {
            if (request.Post == null)
                throw new ArgumentNullException(nameof(request.Post));

            if (request.Post.Id <= 0)
                throw new ArgumentException("Invalid Post ID.");

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
