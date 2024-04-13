using MediatR;
using Domain.User;

namespace Api.Commands
{
    public class LoginCommand : IRequest<LoginDto>
    {
        public string Email { get; set; }
        public string Password { get; set; }

        public LoginCommand(string email, string password)
        {
            Email = email;
            Password = password;
        }
    }

    public record LoginDto
    {
        public User User { get; set; }
    }
}
