

using MediatR;
using Users.Domain.Entities;

namespace Users.Application.Users.Commands.Queries.GetAllUsers;

public class GetAllUsersQuery : IRequest<IEnumerable<User>>
{
}
