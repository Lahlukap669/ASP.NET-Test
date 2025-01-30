
using System.ComponentModel.DataAnnotations;

namespace Users.Application.Users.Dtos;

public class CreateUserDto
{
    [StringLength(100, MinimumLength = 4)]
    public string UserName { get; set; } = default!;
    public string FullName { get; set; } = default!;

    [EmailAddress(ErrorMessage = "Please provide a valid email address!")]
    public string Email { get; set; } = default!;
    
    //[Phone(ErrorMessage = "Please provide a valid phone address!")]
    public string Mobile { get; set; } = default!;
    public string Language { get; set; } = default!;
    public string Culture { get; set; } = default!;
    public string Password { get; set; } = default!;
}

//DataAnnotations allow regex
//Better costum validation will be with FluentValidation (NuGet) -> expecialy for category values