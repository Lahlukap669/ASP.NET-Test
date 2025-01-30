

namespace Users.Application.Users.Dtos;

public class CreateUserDto
{
    public string UserName { get; set; } = default!;
    public string FullName { get; set; } = default!;
    public string Email { get; set; } = default!;
    public string Mobile { get; set; } = default!;
    public string Language { get; set; } = default!;
    public string Culture { get; set; } = default!;
    public string Password { get; set; } = default!;
}
