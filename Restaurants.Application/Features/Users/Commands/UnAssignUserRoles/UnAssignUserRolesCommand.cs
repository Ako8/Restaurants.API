using MediatR;

namespace Restaurants.Application.Features.Users.Commands.UnAssignUserRoles;

public class UnAssignUserRolesCommand : IRequest
{
    public string UserEmail { get; set; } = default!;
    public string RoleName { get; set; } = default!;
}
