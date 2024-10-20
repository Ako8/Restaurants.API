using Microsoft.AspNetCore.Authorization;
using Restaurants.Application.Features.Users;

namespace Restaurants.Infrastructure.Authorization.Requirements.MinimalAge;

public class MinimumAgeRequirementsHandler(IUserContext userContext) : AuthorizationHandler<MinimumAgeRequirements>
{
    protected override Task HandleRequirementAsync(AuthorizationHandlerContext context,
        MinimumAgeRequirements requirement)
    {
        var currentUser = userContext.GetCurrentUser();

        if (currentUser == null)
        {
            context.Fail();
            return Task.CompletedTask;
        }


        if (currentUser.DateOfBirth == null)
        {
            context.Fail();
            return Task.CompletedTask;
        }

        if (currentUser.DateOfBirth.Value.AddYears(requirement.MinimumAge) <= DateOnly.FromDateTime(DateTime.Today))
        {
            context.Succeed(requirement);
        }
        else
        {
            context.Fail();
        }

        return Task.CompletedTask;


    }
}
