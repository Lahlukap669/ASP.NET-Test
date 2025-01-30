using Microsoft.EntityFrameworkCore;
using Users.Domain.Entities;
using Users.Domain.Repositories;
using Users.Infrastructure.Persistence;

namespace Users.Infrastructure.Repositories;

internal class UsersRepository(UsersDbContext DbContext) : IUsersRepository
{
    public async Task<IEnumerable<User>> GetAllAsync()
    {
        var users = await DbContext.Users.ToListAsync();
        return users;
    }
}
