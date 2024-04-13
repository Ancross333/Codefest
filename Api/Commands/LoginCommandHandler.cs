using MediatR;
using Domain.User;
using Domain.Interfaces;

namespace Api.Commands
{
    public class LoginCommandHandler : IRequestHandler<LoginCommand, LoginDto>
    {
        private readonly IUserRepository _repository;
        public LoginCommandHandler( IUserRepository repository)
        {
            _repository = repository;
        }

        public async Task<LoginDto> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            ArgumentNullException.ThrowIfNull(request);

            return await HandleInternalAsync(request, cancellationToken);
        }

        private async Task<LoginDto> HandleInternalAsync(LoginCommand request, CancellationToken cancellationToken)
        {
            User user = await _repository.GetAsync(request.Email, request.Password);

            return new LoginDto()
            {
                User = user
            };
        }
    }
    
    
}
