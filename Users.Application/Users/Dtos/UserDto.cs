
namespace Users.Application.Users.Dtos;
// Currently not used, but if we would want to display only the things form User that we want this is the way to go ...
// Since this is a class, we could map User type over UserDto and display desired info
// Automapper is fastest way for mapping
internal class UserDto
{
    public int Id { get; set; }
    public string UserName { get; set; } = default!;
    public string FullName { get; set; } = default!;
    public string Language { get; set; } = default!;
    public string Culture { get; set; } = default!;
}
