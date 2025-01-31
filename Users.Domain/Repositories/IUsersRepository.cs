using Users.Domain.Entities;

namespace Users.Domain.Repositories;

public interface IUsersRepository
{
    Task<IEnumerable<User>> GetAllAsync();
    Task<User?> GetUserByIdAsync(int id);
    Task<int> Create(User entity);
    Task Delete(User entity);
    Task Update();
    Task<bool> Validate(string email, string password);
    Task AddApiKeyAsync(ApiKey apiKey);
    Task<ApiKey?> GetApiKeyAsync(string key);
    Task<bool> ApiKeyExistsAsync(string key);
}
