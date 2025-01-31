
using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Users.Application.Users.Commands.UpdateUser;
using Users.Domain.Repositories;

namespace Users.Application.Users.Queries.ValidateUser;

public class ValidateUserCredentialsQueryHandler(ILogger<ValidateUserCredentialsQueryHandler> logger,
    IUsersRepository UsersRepository) : IRequestHandler<ValidateUserCredentialsQuery, bool>
{
    public async Task<bool> Handle(ValidateUserCredentialsQuery request, CancellationToken cancellationToken)
    {
        logger.LogInformation("Validating user credentials for {Email}", request.Email);

        var isValid = await UsersRepository.Validate(request.Email, request.Password);
        return isValid;
    }
}
