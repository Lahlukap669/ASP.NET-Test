
using MediatR;

namespace Users.Application.Users.Queries.ValidateApiKey;

public class ValidateApiKeyQuery : IRequest<bool>
{
    public string Key { get; set; } = string.Empty;
}