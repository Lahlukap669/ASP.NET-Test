
using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Users.Domain.Entities;
using Users.Domain.Repositories;

namespace Users.Application.Users.Commands.CreateUser;

public class CreateUserCommandHandler(ILogger<CreateUserCommandHandler> logger,
    IMapper mapper,
    IUsersRepository UsersRepository) : IRequestHandler<CreateUserCommand, int>
{
    public async Task<int> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        logger.LogInformation("Creating new user");

        var user = mapper.Map<User>(request);
        int id = await UsersRepository.Create(user);
        return id;
    }
}
