

using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Users.Domain.Repositories;

namespace Users.Application.Users.Commands.UpdateUser;

public class UpdateUserCommandHandler(ILogger<UpdateUserCommandHandler> logger,
    IUsersRepository UsersRepository,
    IMapper mapper) : IRequestHandler<UpdateUserCommand, bool>
{
    public async Task<bool> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
    {
        logger.LogInformation($"Updating user with id : {request.Id}");
        var user = await UsersRepository.GetUserByIdAsync(request.Id);
        if (user is null)
        {
            return false;
        }
        mapper.Map(request, user);
        
        //user.FullName = request.FullName;
        //user.Email = request.Email;
        //user.Culture = request.Culture;
        //user.Mobile = request.Mobile;
        //user.Password = request.Password;

        await UsersRepository.Update();

        return true;
    }
}
