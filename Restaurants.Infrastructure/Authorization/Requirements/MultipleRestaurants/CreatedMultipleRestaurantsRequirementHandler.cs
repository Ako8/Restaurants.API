using Microsoft.AspNetCore.Authorization;
using Restaurants.Application.Features.Users;
using Restaurants.Domain.Respositories;

namespace Restaurants.Infrastructure.Authorization.Requirements.MultipleRestaurants;

public class CreatedMultipleRestaurantsRequirementHandler(IUserContext userContext, IRestaurantRepository restaurantRepository) : AuthorizationHandler<CreatedMultipleRestaurantsRequirement>
{
    protected async override Task<Task> HandleRequirementAsync(AuthorizationHandlerContext context, CreatedMultipleRestaurantsRequirement requirement)
    {
        var currentUser = userContext.GetCurrentUser();

        if (currentUser == null)
        {
            context.Fail();
            return Task.CompletedTask;
        }

        var restaurants = await restaurantRepository.GetAllAsync();
        var ownedRestaurants = restaurants.Where(u => u.OwnerId == currentUser.Id).ToList();
        
        if (ownedRestaurants.Count() < requirement.CreatedRestaurants)
        {
            context.Fail();
            return Task.CompletedTask;
        }
        else
        {
            context.Succeed(requirement);
        }

        return Task.CompletedTask;
    }
}
