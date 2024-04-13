using Domain.Interfaces;
using Domain.User;
using MediatR;
using Common;
using Infrastructure.Repos;

namespace Api.Commands
{
	public class AddUserCommandHandler : IRequestHandler<AddUserCommand, AddUserDto>
	{
		private readonly IUserRepository _userRepository;
		private readonly IValuesRepository _valuesRepository;

		public AddUserCommandHandler(IUserRepository userRepository, IValuesRepository valuesRepository)
		{
			_userRepository = userRepository;
			_valuesRepository = valuesRepository;
		}

		public async Task<AddUserDto> Handle(AddUserCommand request, CancellationToken cancellationToken)
		{
			ArgumentNullException.ThrowIfNull(request);

			return await HandleInternalAsync(request, cancellationToken);
		}

		private async Task<AddUserDto> HandleInternalAsync(AddUserCommand request, CancellationToken cancellationToken)
		{
			var newPassword = PasswordUtils.HashPassword(request.Password);
			User user = new(request.Email, newPassword, request.CompanyName,
				request.FirstName, request.LastName, request.Zip, request.AccountType, request.ProfilePicture);

			await _valuesRepository.AddAsync(request.Values, user.Id);
			await _userRepository.AddAsync(user);
			await _userRepository.SaveChangesAsync();

			return new AddUserDto()
			{
				UserId = user.Id
			};
		}
	}
}
