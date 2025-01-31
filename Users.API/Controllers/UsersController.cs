using Microsoft.AspNetCore.Mvc;
using Users.Application.Users;
using Users.Application.Users.Dtos;
using MediatR;
using Users.Application.Users.Queries.GetAllUsers;
using Users.Application.Users.Queries.GetUserById;
using Users.Application.Users.Commands.CreateUser;
using Users.Application.Users.Commands.DeleteUser;
using Users.Application.Users.Commands.UpdateUser;
using Users.Domain.Entities;
using Users.Application.Users.Queries.ValidateUser;
using Users.Application.Users.Commands.CreateApiKey;
using Users.Application.Users.Queries.ValidateApiKey;

namespace Users.API.Controllers;

[ApiController]
[Route("api/users")]
public class UsersController(IMediator mediator) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<IEnumerable<User>>> GetAll() 
    {
        var users = await mediator.Send(new GetAllUsersQuery());
        return Ok(users);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<User?>> GetById([FromRoute] int id) 
    {
        var user = await mediator.Send(new GetUserByIdQuery(id));
        if (user is null) {
            return NotFound();
        }
        return Ok(user);
    }
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
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
    [HttpPatch("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> UpdateUser([FromRoute] int id, UpdateUserCommand command)
    {
        command.Id = id;
        var isUpdated = await mediator.Send(command);
        if (isUpdated)
        {
            return NoContent();
        }
        return NotFound();
    }
    [HttpPost("validate-credentials")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> ValidateCredentials([FromBody] ValidateUserCredentialsQuery query)
    {
        if (string.IsNullOrWhiteSpace(query.Email) || string.IsNullOrWhiteSpace(query.Password))
        {
            return BadRequest("Email and password must not be empty.");
        }

        var isValid = await mediator.Send(query);

        if (isValid)
        {
            return Ok("Credentials are valid.");
        }

        return BadRequest("Invalid email or password.");
    }
    [HttpPost("generate-api-key")]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public async Task<IActionResult> GenerateApiKey([FromBody] CreateApiKeyCommand command)
    {
        var apiKey = await mediator.Send(command);
        return Created("", new { ApiKey = apiKey });
    }

    [HttpPost("validate-api-key")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> ValidateApiKey([FromBody] ValidateApiKeyQuery query)
    {
        var isValid = await mediator.Send(query);
        if (!isValid)
        {
            return BadRequest("Invalid API Key.");
        }
        return Ok("API Key is valid.");
    }

}
