
using MediatR;
using Restaurants.Domain.Respositories;
using Restaurants.Domain.Exceptions;
using Restaurants.Domain.Entities;
using AutoMapper;
using Restaurants.Domain.Interface;
using Restaurants.Infrastructure.Authorization;
namespace Restaurants.Application.Features.Dishes.Commands.CreateDish;

public class CreateDishCommandHandler(IRestaurantRepository restaurantRepository,
    IDishesRepository dishesRepository,
    IMapper mapper,
    IRestaurantAuthorizationService restaurantAuthorizationService) : IRequestHandler<CreateDishCommand, int>
{
    public async Task<int> Handle(CreateDishCommand request, CancellationToken cancellationToken)
    {
        var restaurant = await restaurantRepository.GetByIdAsync(request.RestaurantId);
        if (restaurant == null) throw new NotFoundException(nameof(Restaurant), request.RestaurantId.ToString());

        if (!restaurantAuthorizationService.Authorize(restaurant, ResourceOperatoin.Update))
            throw new ForbidException();

        var dish = mapper.Map<Dish>(request);
        var result = await dishesRepository.Create(dish);
        return result;
    }
}
