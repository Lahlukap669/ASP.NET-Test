using Users.Domain.Entities;
using Users.Infrastructure.Persistence;
using Microsoft.Extensions.Logging;

namespace Users.Infrastructure.Seeders;

public class ApiKeySeeder(UsersDbContext dbContext, ILogger<ApiKeySeeder> logger) : IApiKeySeeder
{
    public async Task SeedAsync()
    {
        if (!dbContext.ApiKeys.Any())
        {
            logger.LogInformation("Seeding API keys...");

            var apiKey = new ApiKey
            {
                ClientName = "DefaultClient",
                Key = Convert.ToBase64String(Guid.NewGuid().ToByteArray())
                    .Replace("=", "")
                    .Replace("+", "")
                    .Replace("/", ""),
                IsActive = true
            };

            dbContext.ApiKeys.Add(apiKey);
            await dbContext.SaveChangesAsync();

            logger.LogInformation("Seeded API keys successfully.");
        }
        else
        {
            logger.LogInformation("API keys already seeded.");
        }
    }
}
