using Users.Infrastructure.Persistence;
using Users.Domain.Entities;

namespace Users.Infrastructure.Seeders
{
    internal class UserSeeder(UsersDbContext dbContext) : IUserSeeder
    {
        public async Task Seed()
        {
            if (await dbContext.Database.CanConnectAsync())
            {
                if (!dbContext.Users.Any())
                {
                    var users = GetUsers();
                    dbContext.Users.AddRange(users);
                    await dbContext.SaveChangesAsync();
                }
            }
        }
        private IEnumerable<User> GetUsers()
        {
            List<User> Users = [
                new()
                {
                    UserName = "Lahlukap669",
                    FullName = "Luka Lah",
                    Email = "luka1.lah@gmail.com",
                    Mobile = "/",
                    Language = "English",
                    Culture = "Christian",
                    Password = "admin"
                },
                new()
                {
                    UserName = "Lahluka",
                    FullName = "Luka Lah",
                    Email = "luka11.lah@gmail.com",
                    Mobile = "/",
                    Language = "English",
                    Culture = "Christian",
                    Password = "luka123"
                }
            ];
            return Users;
        }
    }
}
