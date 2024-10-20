using Restaurants.Application.Features.Users;
using Restaurants.Domain.Constants;
using Restaurants.Domain.Entities;
using Restaurants.Domain.Exceptions;
using Restaurants.Domain.Interface;

namespace Restaurants.Infrastructure.Authorization.Services;

public class RestaurantAuthorizationService(IUserContext userContext) : IRestaurantAuthorizationService
{
    public bool Authorize(Restaurant restaurant, ResourceOperatoin resourceOperatoin)
    {
        var user = userContext.GetCurrentUser()
            ?? throw new ForbidException();

        if (resourceOperatoin == ResourceOperatoin.Read || resourceOperatoin == ResourceOperatoin.Create)
        {
            return true;
        }

        if (resourceOperatoin == ResourceOperatoin.Delete && user.IsInRole(UserRoles.Admin))
        {
            return true;
        }

        if ((resourceOperatoin == ResourceOperatoin.Delete || resourceOperatoin == ResourceOperatoin.Update)
            && user.Id == restaurant.OwnerId)
        {
            return true;
        }

        return false;
    }
}
