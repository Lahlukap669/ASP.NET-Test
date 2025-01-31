

using MediatR;
using Users.Domain.Entities;

namespace Users.Application.Users.Queries.GetAllUsers;

public class GetAllUsersQuery : IRequest<IEnumerable<User>>
{
}
