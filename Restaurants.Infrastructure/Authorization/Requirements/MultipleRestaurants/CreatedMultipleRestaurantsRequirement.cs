using Microsoft.AspNetCore.Authorization;

namespace Restaurants.Infrastructure.Authorization.Requirements.MultipleRestaurants;

public class CreatedMultipleRestaurantsRequirement(int createdRestaurants) : IAuthorizationRequirement
{
    public int CreatedRestaurants { get; set; } = createdRestaurants;
}
