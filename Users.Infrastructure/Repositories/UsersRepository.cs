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
    public async Task<User?> GetUserByIdAsync(int id)
    {
        var user = await DbContext.Users.FirstOrDefaultAsync(x => x.Id == id);
        return user;
    }
    public async Task<int> Create(User entity)
    {
        DbContext.Users.Add(entity);
        await DbContext.SaveChangesAsync();
        return entity.Id;
    }
}
