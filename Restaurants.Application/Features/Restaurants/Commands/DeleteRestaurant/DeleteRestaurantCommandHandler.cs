
using MediatR;
using Microsoft.Extensions.Logging;
using Restaurants.Domain.Respositories;
using Restaurants.Domain.Exceptions;
using Restaurants.Domain.Interface;
using Restaurants.Infrastructure.Authorization;
using Restaurants.Application.Features.Users;


namespace Restaurants.Application.Features.Restaurants.Commands.DeleteRestaurant;

public class DeleteRestaurantCommandHandler(ILogger<DeleteRestaurantCommandHandler> logger,
    IRestaurantRepository restaurantRepository,
    IRestaurantAuthorizationService restaurantAuthorizationService) : IRequestHandler<DeleteRestaurantCommand>
{
    public async Task Handle(DeleteRestaurantCommand request, CancellationToken cancellationToken)
    {
        logger.LogInformation("deleting restaurant with id");
        var restaurant = await restaurantRepository.GetByIdAsync(request.Id);
        if (restaurant is null) throw new NotFoundException("Restaurant", request.Id.ToString());

        if (!restaurantAuthorizationService.Authorize(restaurant, ResourceOperatoin.Delete))
            throw new ForbidException();
        
        await restaurantRepository.Delete(restaurant);
    }
}
