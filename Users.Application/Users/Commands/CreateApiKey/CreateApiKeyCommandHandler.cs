
using MediatR;
using Users.Domain.Entities;
using Users.Domain.Repositories;

namespace Users.Application.Users.Commands.CreateApiKey;

public class CreateApiKeyCommandHandler : IRequestHandler<CreateApiKeyCommand, string>
{
    private readonly IUsersRepository _usersRepository;

    public CreateApiKeyCommandHandler(IUsersRepository usersRepository)
    {
        _usersRepository = usersRepository;
    }

    public async Task<string> Handle(CreateApiKeyCommand request, CancellationToken cancellationToken)
    {
        // Generate API Key
        var apiKey = Convert.ToBase64String(Guid.NewGuid().ToByteArray())
            .Replace("=", "")
            .Replace("+", "")
            .Replace("/", "");

        // Save API Key to the database
        await _usersRepository.AddApiKeyAsync(new ApiKey
        {
            ClientName = request.ClientName,
            Key = apiKey,
            IsActive = true
        });

        return apiKey;
    }
}
