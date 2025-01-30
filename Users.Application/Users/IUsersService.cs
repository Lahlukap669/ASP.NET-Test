using Users.Domain.Entities;
using Users.Application.Users.Dtos;

namespace Users.Application.Users
{
    public interface IUsersService
    {
        Task<IEnumerable<User>> GetAllUsers();
        Task<User?> GetUserById(int id);
        Task<int> Create(CreateUserDto dto);
    }
}