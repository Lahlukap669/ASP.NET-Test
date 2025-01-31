
using MediatR;
using Users.Domain.Entities;

namespace Users.Application.Users.Commands.Queries.GetUserById;

public class GetUserByIdQuery(int id) : IRequest<User?>
{
    public int Id { get; } = id;
}
