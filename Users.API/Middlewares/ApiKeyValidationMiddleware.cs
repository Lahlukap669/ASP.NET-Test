using Users.Domain.Repositories;

namespace Users.API.Middlewares;

public class ApiKeyValidationMiddleware(ILogger<ApiKeyValidationMiddleware> logger, IUsersRepository usersRepository) : IMiddleware
{
    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        // Skip API key validation for Swagger UI and Swagger JSON
        if (context.Request.Path.StartsWithSegments("/swagger"))
        {
            await next(context);
            return;
        }

        // Check for API Key in headers
        if (!context.Request.Headers.TryGetValue("X-API-KEY", out var apiKey))
        {
            context.Response.StatusCode = StatusCodes.Status401Unauthorized;
            await context.Response.WriteAsync("API Key is missing.");
            return;
        }

        // Validate API Key
        var apiKeyEntity = await usersRepository.GetApiKeyAsync(apiKey);
        if (apiKeyEntity == null || !apiKeyEntity.IsActive)
        {
            context.Response.StatusCode = StatusCodes.Status403Forbidden;
            await context.Response.WriteAsync("Invalid API Key.");
            return;
        }

        logger.LogInformation("API called by Client: {ClientName}, Endpoint: {Path}, Time: {Time}",
            apiKeyEntity.ClientName,
            context.Request.Path,
            DateTime.UtcNow);

        await next(context);
    }
}
