using MediatR;

namespace Users.Application.Users.Queries.ValidateUser;

public class ValidateUserCredentialsQuery : IRequest<bool>
{
    public string Email { get; set; } = default!;
    public string Password { get; set; } = default!;
}
