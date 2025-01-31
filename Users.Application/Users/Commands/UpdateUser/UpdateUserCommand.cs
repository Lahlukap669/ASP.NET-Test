
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace Users.Application.Users.Commands.UpdateUser;

public class UpdateUserCommand : IRequest<bool>
{
    public int Id { get; set; }
    public string FullName { get; set; } = default!;

    [EmailAddress(ErrorMessage = "Please provide a valid email address!")]
    public string Email { get; set; } = default!;

    //[Phone(ErrorMessage = "Please provide a valid phone address!")]
    public string Mobile { get; set; } = default!;
    public string Culture { get; set; } = default!;
    public string Password { get; set; } = default!;
}
