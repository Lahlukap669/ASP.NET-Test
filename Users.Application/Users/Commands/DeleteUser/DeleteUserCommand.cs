

using MediatR;

namespace Users.Application.Users.Commands.DeleteUser;

public class DeleteUserCommand(int id) : IRequest<bool>
{
    public int Id { get; } = id;
}
