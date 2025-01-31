
using MediatR;
using Microsoft.Extensions.Logging;
using Users.Domain.Entities;
using Users.Domain.Repositories;

namespace Users.Application.Users.Commands.DeleteUser;

public class DeleteUserCommandHandler(ILogger<DeleteUserCommandHandler> logger,
    IUsersRepository UsersRepository) : IRequestHandler<DeleteUserCommand, bool>
{
    public async Task<bool> Handle(DeleteUserCommand request, CancellationToken cancellationToken) 
    {
        logger.LogInformation($"Deleting user with id : {request.Id}");
        var user = await UsersRepository.GetUserByIdAsync(request.Id);
        if (user is null) 
        {
            return false;
        }
        await UsersRepository.Delete(user);
        return true;
    }

}
