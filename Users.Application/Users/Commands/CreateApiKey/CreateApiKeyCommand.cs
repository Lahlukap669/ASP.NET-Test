
using MediatR;

namespace Users.Application.Users.Commands.CreateApiKey;

public class CreateApiKeyCommand : IRequest<string>
{
    public string ClientName { get; set; } = string.Empty;
}
