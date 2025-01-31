using MediatR;
using Users.Application.Users.Queries.ValidateApiKey;
using Users.Domain.Repositories;

namespace Users.Application.Users.Queries.ApiKey;

public class ValidateApiKeyQueryHandler(IUsersRepository usersRepository) : IRequestHandler<ValidateApiKeyQuery, bool>
{
    public async Task<bool> Handle(ValidateApiKeyQuery request, CancellationToken cancellationToken)
    {
        var apiKey = await usersRepository.GetApiKeyAsync(request.Key);
        return apiKey != null && apiKey.IsActive;
    }
}
