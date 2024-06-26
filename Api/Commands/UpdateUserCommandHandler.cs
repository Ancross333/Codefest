﻿using MediatR;
using Domain.User;
using Domain.Interfaces;
using Common;

namespace Api.Commands
{
    public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, UpdateUserDto>
    {
        private readonly IUserRepository _repository;
        public UpdateUserCommandHandler(IUserRepository repository)
        {
            _repository = repository;
        }

        public async Task<UpdateUserDto> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            ArgumentNullException.ThrowIfNull(request);

            return await HandleInternalAsync(request, cancellationToken);
        }

        private async Task<UpdateUserDto> HandleInternalAsync(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            await _repository.UpdateAsync( request.Id, request.Email, request.CompanyName, request.FirstName, request.LastName, request.Zip, request.AccountType, request.ProfilePicture);


            return new UpdateUserDto()
            {
                Id = request.Id
            };
        }

    }
}
