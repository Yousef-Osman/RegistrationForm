using MediatR;
using Microsoft.AspNetCore.Mvc;
using RegistrationForm.Application.Commands.User.Create;
using RegistrationForm.Application.Commands.User.Delete;
using RegistrationForm.Application.Commands.User.Update;
using RegistrationForm.Application.Queries.User.GetAll;
using RegistrationForm.Application.Queries.User.GetById;

namespace RegistrationForm.Api.Controllers;
[Route("api/[controller]")]
[ApiController]
public class UsersController : ControllerBase
{
    private readonly ISender _mediator;

    public UsersController(ISender mediator)
    {
        _mediator = mediator;
    }

    [HttpGet("Get/{id}")]
    public async Task<IActionResult> GetUser(long id)
    {
        var query = new GetUserByIdQuery { Id = id };

        var result = await _mediator.Send(query);

        if (result == null)
            return NotFound();

        return Ok(result);
    }

    [HttpGet("GetAll")]
    public async Task<IActionResult> GetAll()
    {
        var query = new GetAllUsersQuery();
        var users = await _mediator.Send(query);

        return Ok(users);
    }

    [HttpPost("Create")]
    public async Task<IActionResult> Create(CreateUserCommand command)
    {
        var result = await _mediator.Send(command);

        return Ok(result);
    }

    [HttpPut("Update/{id}")]
    public async Task<IActionResult> Update(long id, UpdateUserCommand command)
    {
        if (command.Id != id)
            return BadRequest();

        await _mediator.Send(command);

        return NoContent();
    }

    [HttpDelete("Delete/{id}")]
    public async Task<IActionResult> Delete(long id)
    {
        var command = new DeleteUserCommand { Id = id };
        await _mediator.Send(command);

        return NoContent();
    }
}
