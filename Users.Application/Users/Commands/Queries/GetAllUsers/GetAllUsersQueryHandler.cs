using MediatR;
using Microsoft.Extensions.Logging;
using Users.Domain.Entities;
using Users.Domain.Repositories;

namespace Users.Application.Users.Commands.Queries.GetAllUsers;

public class GetAllUsersQueryHandler(ILogger<GetAllUsersQueryHandler> logger,
    IUsersRepository UsersRepository) : IRequestHandler<GetAllUsersQuery, IEnumerable<User>>
{
    public async Task<IEnumerable<User>> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
    {
        logger.LogInformation("Getting all Users");
        var users = await UsersRepository.GetAllAsync();
        return users;
    }
}
