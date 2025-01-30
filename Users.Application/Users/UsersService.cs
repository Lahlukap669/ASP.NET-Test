using AutoMapper;
using Microsoft.Extensions.Logging;
using Users.Application.Users.Dtos;
using Users.Domain.Entities;
using Users.Domain.Repositories;

namespace Users.Application.Users;

internal class UsersService(IUsersRepository UsersRepository,
    ILogger<UsersService> logger, 
    IMapper mapper) : IUsersService
{
    public Task<IEnumerable<User>> GetAllUsers()
    {
        logger.LogInformation("Getting all Users");
        var users = UsersRepository.GetAllAsync();
        return users;
    }
    public Task<User?> GetUserById(int id)
    {
        logger.LogInformation("Getting User by ID");
        var user = UsersRepository.GetUserByIdAsync(id);
        return user;
    }
    public async Task<int> Create(CreateUserDto dto) 
    {
        logger.LogInformation("Creating new user");

        var user = mapper.Map<User>(dto);
        int id = await UsersRepository.Create(user);
        return id;
    }
}
