using MediatR;
using Microsoft.AspNetCore.Mvc;
using RegistrationForm.Application.Commands.Users.Create;
using RegistrationForm.Application.Commands.Users.Delete;
using RegistrationForm.Application.Commands.Users.Update;
using RegistrationForm.Application.Queries.Cities.GetByGovernate;
using RegistrationForm.Application.Queries.Governates.GetAll;
using RegistrationForm.Application.Queries.Users.GetAll;
using RegistrationForm.Application.Queries.Users.GetById;

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

    [HttpGet("Governates")]
    public async Task<IActionResult> GetGovernates()
    {
        var query = new GetAllGovernatesQuery();
        var users = await _mediator.Send(query);

        return Ok(users);
    }

    [HttpGet("Cities/{id}")]
    public async Task<IActionResult> GetCities(long id)
    {
        var query = new GetCitiesByGovernateQuery { Id = id };
        var users = await _mediator.Send(query);

        return Ok(users);
    }
}
