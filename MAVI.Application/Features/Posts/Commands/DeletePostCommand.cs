using MAVI.Domain.Interfaces.Repositories;
using MediatR;

namespace MAVI.Application.Features.Posts.Commands
{
    public record DeletePostCommand(int PostId) : IRequest<bool>;

    public class DeletePostHandler(IPostRepository repository) : IRequestHandler<DeletePostCommand, bool>
    {
        public async Task<bool> Handle(DeletePostCommand request, CancellationToken cancellationToken)
        {
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
