using MediatR;
using Domain.User;
using Domain.Interfaces;
using Common;

namespace Api.Commands
{
    public class LoginCommandHandler : IRequestHandler<LoginCommand, LoginDto>
    {
        private readonly IUserRepository _userRepository;
        private readonly IValuesRepository _valuesRepository;

		public LoginCommandHandler(IUserRepository userRepository, IValuesRepository valuesRepository)
		{
			_userRepository = userRepository;
			_valuesRepository = valuesRepository;
		}

		public async Task<LoginDto> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            ArgumentNullException.ThrowIfNull(request);

            return await HandleInternalAsync(request, cancellationToken);
        }

        private async Task<LoginDto> HandleInternalAsync(LoginCommand request, CancellationToken cancellationToken)
        {
            User user = await _userRepository.GetAsync(request.Email, request.Password);
            user.Values = _valuesRepository.GetValues(user.Id);

            if(user != null)
            {
                if(PasswordUtils.VerifyPassword(user.Password, request.Password))
                {
                    return new LoginDto()
                    {
                        User = user
                    };
                }
            }


            return new LoginDto()
            {
                User = null
            };
        }
    }
    
    
}
