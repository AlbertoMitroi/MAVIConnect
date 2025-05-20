using MAVI.Domain.Interfaces.Repositories;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace MAVI.Application.Features.Posts.Commands
{
    public record DeletePostCommand(int PostId) : IRequest<bool>;

    public class DeletePostHandler(IPostRepository repository) : IRequestHandler<DeletePostCommand, bool>
    {
        public async Task<bool> Handle(DeletePostCommand request, CancellationToken cancellationToken)
        {
            if (request.PostId <= 0)
            {
                throw new ArgumentException("Invalid post ID.");
            }

            var post = await repository.GetByIdAsync(request.PostId, cancellationToken);
            if (post == null)
            {
                return false;
            }

            await repository.DeleteAsync(request.PostId, cancellationToken);
            await repository.SaveChangesAsync(cancellationToken);
            return true;
        }
    }
}
