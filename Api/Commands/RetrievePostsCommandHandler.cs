using MediatR;
using Domain.Post;
using Domain.Interfaces;

namespace Api.Commands
{
    public class RetrievePostsCommandHandler : IRequestHandler<RetrievePostsCommand, RetrievePostsDto>
    {
        private readonly IPostsRepository _repository;

        public RetrievePostsCommandHandler(IPostsRepository repository)
        {
            _repository = repository;
        }

        public async Task<RetrievePostsDto> Handle(RetrievePostsCommand request, CancellationToken cancellationToken)
        {
            ArgumentNullException.ThrowIfNull(request);

            return await HandleInternalAsync(request, cancellationToken);
        }

        private async Task<RetrievePostsDto> HandleInternalAsync(RetrievePostsCommand request, CancellationToken cancellationToken)
        {
            List<Post> posts = _repository.Get(request.UserId, request.StartingPostId);

            return new RetrievePostsDto()
            {
                Posts = posts
            };
        }
    }
    
 
}
