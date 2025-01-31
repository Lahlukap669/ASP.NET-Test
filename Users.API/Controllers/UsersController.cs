using Microsoft.AspNetCore.Mvc;
using Users.Application.Users;
using Users.Application.Users.Dtos;
using MediatR;
using Users.Application.Users.Commands.Queries.GetAllUsers;
using Users.Application.Users.Commands.Queries.GetUserById;
using Users.Application.Users.Commands.CreateUser;
using Users.Application.Users.Commands.DeleteUser;

namespace Users.API.Controllers;

[ApiController]
[Route("api/users")]
public class UsersController(IMediator mediator) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAll() 
    {
        var users = await mediator.Send(new GetAllUsersQuery());
        return Ok(users);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] int id) 
    {
        var user = await mediator.Send(new GetUserByIdQuery(id));
        if (user is null) {
            return NotFound();
        }
        return Ok(user);
    }
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteUser([FromRoute] int id)
    {
        var isDeleted = await mediator.Send(new DeleteUserCommand(id));
        if (isDeleted)
        {
            return NoContent();
        }
        return NotFound();
    }
    [HttpPost]
    public async Task<IActionResult> CreateUser([FromBody] CreateUserCommand command) 
    {
        int id = await mediator.Send(command);
        return CreatedAtAction(nameof(GetById), new { id }, null);
    }
}
