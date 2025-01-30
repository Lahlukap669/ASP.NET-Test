using Users.Domain.Entities;

namespace Users.Application.Users
{
    public interface IUsersService
    {
        Task<IEnumerable<User>> GetAllUsers();
    }
}