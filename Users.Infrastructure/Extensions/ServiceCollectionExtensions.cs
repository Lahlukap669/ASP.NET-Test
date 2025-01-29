using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Users.Infrastructure.Persistence;
using Microsoft.Extensions.Configuration;
using Users.Infrastructure.Seeders;

namespace Users.Infrastructure.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration) 
        {
            var connectionString = configuration.GetConnectionString("UsersDb");
            services.AddDbContext<UsersDbContext>(options => options.UseSqlServer(connectionString));

            services.AddScoped<IUserSeeder, UserSeeder>();

        }
    }
}
