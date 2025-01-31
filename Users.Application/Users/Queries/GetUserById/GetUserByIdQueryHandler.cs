using MediatR;
using Microsoft.Extensions.Logging;
using Users.Application.Users.Queries.GetAllUsers;
using Users.Domain.Entities;
using Users.Domain.Repositories;

namespace Users.Application.Users.Queries.GetUserById;

public class GetUserByIdQueryHandler(ILogger<GetUserByIdQueryHandler> logger,
    IUsersRepository UsersRepository) : IRequestHandler<GetUserByIdQuery, User?>
{
    public async Task<User?> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
    {
        logger.LogInformation("Getting User by ID");
        var user = await UsersRepository.GetUserByIdAsync(request.Id);
        return user;
    }
}
