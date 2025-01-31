using Users.Infrastructure.Extensions;
using Users.Infrastructure.Seeders;
using Users.Application.Extensions;
using Users.Application.Users.Dtos;
using Serilog;
using Users.API.Middlewares;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<ErrorHandlingMiddleware>();
builder.Services.AddApplication();

builder.Services.AddInfrastructure(builder.Configuration);
builder.Services.AddAutoMapper(typeof(UsersProfile));
builder.Host.UseSerilog((context, configuration) =>
    configuration
        .ReadFrom.Configuration(context.Configuration)
        .Enrich.FromLogContext() // Ensure dynamic log context enrichment
);

var app = builder.Build();

var scope = app.Services.CreateScope();

var seeder = scope.ServiceProvider.GetRequiredService<IUserSeeder>();

await seeder.Seed();


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
