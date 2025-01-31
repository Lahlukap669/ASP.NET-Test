using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Users.Infrastructure.Persistence;
using Microsoft.Extensions.Configuration;
using Users.Infrastructure.Seeders;
using Users.Infrastructure.Repositories;
using Users.Domain.Repositories;

namespace Users.Infrastructure.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration) 
        {
            var connectionString = configuration.GetConnectionString("UsersDb");
            services.AddDbContext<UsersDbContext>(options => options.UseSqlServer(connectionString).EnableSensitiveDataLogging());

            services.AddScoped<IUserSeeder, UserSeeder>();
            services.AddScoped<IUsersRepository, UsersRepository>();
        }
    }
}
