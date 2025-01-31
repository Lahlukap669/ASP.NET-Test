using Users.Infrastructure.Extensions;
using Users.Infrastructure.Seeders;
using Users.Application.Extensions;
using Users.Application.Users.Dtos;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddApplication();

builder.Services.AddInfrastructure(builder.Configuration);
builder.Services.AddAutoMapper(typeof(UsersProfile));
builder.Host.UseSerilog((context, configuration) =>
    configuration
        .ReadFrom.Configuration(context.Configuration)
        .Enrich.FromLogContext() // Ensure dynamic log context enrichment
);

var app = builder.Build();

app.Use(async (context, next) =>
{
    var clientIp = context.Connection.RemoteIpAddress?.ToString() ?? "Unknown";
    Serilog.Context.LogContext.PushProperty("ClientIP", clientIp);
    await next.Invoke();
});

var scope = app.Services.CreateScope();

var seeder = scope.ServiceProvider.GetRequiredService<IUserSeeder>();

await seeder.Seed();
// Configure the HTTP request pipeline.


app.UseHttpsRedirection();
app.UseSerilogRequestLogging();

app.UseAuthorization();

app.MapControllers();

app.Run();
