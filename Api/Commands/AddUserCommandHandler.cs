using Domain.Interfaces;
using Domain.User;
using Domain.Values;
using MediatR;
using Common;

namespace Api.Commands
{
	public class AddUserCommandHandler : IRequestHandler<AddUserCommand, AddUserDto>
	{
		private readonly IUserRepository _repository;

		public AddUserCommandHandler(IUserRepository repository)
		{
			_repository = repository;
		}

		public async Task<AddUserDto> Handle(AddUserCommand request, CancellationToken cancellationToken)
		{
			ArgumentNullException.ThrowIfNull(request);

			return await HandleInternalAsync(request, cancellationToken);
		}

		private async Task<AddUserDto> HandleInternalAsync(AddUserCommand request, CancellationToken cancellationToken)
		{
			var newPassword = PasswordUtils.HashPassword(request.Password);
			User user = new(request.Email, request.Password, request.CompanyName,
				request.FirstName, request.LastName, request.Zip, request.AccountType, request.ProfilePicture);

			await _repository.AddAsync(user);
			await _repository.SaveChangesAsync();

			return new AddUserDto()
			{
				UserId = user.Id
		};
		}
	}
}
