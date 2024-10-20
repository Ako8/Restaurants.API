using AutoMapper;
using MediatR;
using Restaurants.Domain.Entities;
using Restaurants.Domain.Exceptions;
using Restaurants.Domain.Interface;
using Restaurants.Domain.Respositories;
using Restaurants.Infrastructure.Authorization;

namespace Restaurants.Application.Features.Dishes.Commands.DeleteDishForRestaurant;

public class DeleteDishForRestaurantCommandHandler(IRestaurantRepository restaurantRepository,
    IDishesRepository dishesRepository,
    IRestaurantAuthorizationService restaurantAuthorizationService) : IRequestHandler<DeleteDishForRestaurantCommand>
{
    public async Task Handle(DeleteDishForRestaurantCommand request, CancellationToken cancellationToken)
    {
        var restaurant = await restaurantRepository.GetByIdAsync(request.RestaurantId);
        if (restaurant == null) throw new NotFoundException(nameof(Restaurant), request.RestaurantId.ToString());

        var dish = restaurant.Dishes.FirstOrDefault(d => d.Id == request.DishId);
        if (dish == null) throw new NotFoundException(nameof(Dish), request.DishId.ToString());

        if (!restaurantAuthorizationService.Authorize(restaurant, ResourceOperatoin.Delete))
            throw new ForbidException();

        await dishesRepository.Delete(dish);
    }
}
