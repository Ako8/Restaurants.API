using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Restaurants.Application.Features.Users.Commands.AssignUserRoles;
using Restaurants.Application.Features.Users.Commands.UnAssignUserRoles;
using Restaurants.Application.Features.Users.Commands.UpdateUser;
using Restaurants.Domain.Constants;

namespace Restaurants.API.Controllers;

[ApiController]
[Route("api/identity")]
public class IdentityController(IMediator mediator) : ControllerBase
{
    [HttpPatch("user")]
    [Authorize]
    public async Task<IActionResult> UpdateUserDetails(UpdateUserDetailsCommand command)
    {
        await mediator.Send(command);
        return NoContent();
    }

    [HttpPost("userRole")]
    [Authorize(Roles = UserRoles.Admin)]
    public async Task<IActionResult> AssignUserRoles(AssignUserRolesCommand command)
    {
        await mediator.Send(command);
        return NoContent();
    }

    [HttpDelete("userRole")]
    [Authorize(Roles = UserRoles.Admin)]
    public async Task<IActionResult> UnAssignUserRoles(UnAssignUserRolesCommand command)
    {
        await mediator.Send(command);
        return NoContent();
    }

    //[HttpPost("register")]
    //[AllowAnonymous]
    //public async Task<IActionResult> RegisterUser([FromBody] RegisterUserCommand command)
    //{
    //    await mediator 
    //    return NoContent();
    //}
}
