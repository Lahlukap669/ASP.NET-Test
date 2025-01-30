using Microsoft.AspNetCore.Mvc;
using Users.Application.Users;

namespace Users.API.Controllers;

[ApiController]
[Route("api/users")]
public class UsersController(IUsersService UsersService) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAll() 
    {
        var users = await UsersService.GetAllUsers();
        return Ok(users);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] int id) 
    {
        var user = await UsersService.GetUserById(id);
        if (user is null) {
            return NotFound();
        }
        return Ok(user);
    }
}
