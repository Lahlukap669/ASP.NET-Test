using Users.Infrastructure.Extensions;
using Users.Infrastructure.Seeders;
using Users.Application.Extensions;
using Users.Application.Users.Dtos;
using Serilog;
using Users.API.Middlewares;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddSwaggerGen(options =>
{
    options.AddSecurityDefinition("ApiKey", new Microsoft.OpenApi.Models.OpenApiSecurityScheme
    {
        Description = "API Key needed to access the endpoints. Add it to the `X-API-KEY` header.",
        Type = Microsoft.OpenApi.Models.SecuritySchemeType.ApiKey,
        Name = "X-API-KEY",
        In = Microsoft.OpenApi.Models.ParameterLocation.Header,
        Scheme = "ApiKeyScheme"
    });

    options.AddSecurityRequirement(new Microsoft.OpenApi.Models.OpenApiSecurityRequirement
    {
        {
            new Microsoft.OpenApi.Models.OpenApiSecurityScheme
            {
                Reference = new Microsoft.OpenApi.Models.OpenApiReference
                {
                    Type = Microsoft.OpenApi.Models.ReferenceType.SecurityScheme,
                    Id = "ApiKey"
                },
                Scheme = "ApiKeyScheme",
                Name = "ApiKey",
                In = Microsoft.OpenApi.Models.ParameterLocation.Header
            },
            new List<string>()
        }
    });
});

builder.Services.AddScoped<ErrorHandlingMiddleware>();
builder.Services.AddScoped<ApiKeyValidationMiddleware>();
builder.Services.AddApplication();

builder.Services.AddInfrastructure(builder.Configuration);
builder.Services.AddAutoMapper(typeof(UsersProfile));
builder.Host.UseSerilog((context, configuration) =>
    configuration
        .ReadFrom.Configuration(context.Configuration)
        .Enrich.FromLogContext()
);

var app = builder.Build();

var scope = app.Services.CreateScope();

var seeder = scope.ServiceProvider.GetRequiredService<IUserSeeder>();

await seeder.Seed();

var apiKeySeeder = scope.ServiceProvider.GetRequiredService<IApiKeySeeder>();
await apiKeySeeder.SeedAsync();

app.UseMiddleware<ApiKeyValidationMiddleware>();

app.UseMiddleware<ErrorHandlingMiddleware>();
app.Use(async (context, next) =>
{
    var clientIp = context.Connection.RemoteIpAddress?.ToString() ?? "Unknown";
    Serilog.Context.LogContext.PushProperty("ClientIP", clientIp);
    await next.Invoke();
});


// Configure the HTTP request pipeline.

app.UseSerilogRequestLogging();
app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();
app.UseAuthorization();

app.MapControllers();

app.Run();
