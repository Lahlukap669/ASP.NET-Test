using Users.Domain.Entities;

namespace Users.Application.Users
{
    public interface IUsersService
    {
        Task<IEnumerable<User>> GetAllUsers();
        Task<User?> GetUserById(int id);
    }
}