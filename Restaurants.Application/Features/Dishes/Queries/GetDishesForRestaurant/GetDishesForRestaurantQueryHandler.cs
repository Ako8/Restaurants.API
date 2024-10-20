using AutoMapper;
using MediatR;
using Restaurants.Application.Features.Dishes.Dtos;
using Restaurants.Domain.Entities;
using Restaurants.Domain.Exceptions;
using Restaurants.Domain.Respositories;

namespace Restaurants.Application.Features.Dishes.Queries.GetDishesForRestaurant;

public class GetDishesForRestaurantQueryHandler(IRestaurantRepository restaurantRepository, IMapper mapper) : IRequestHandler<GetDishesForRestaurantQuery, IEnumerable<DishDto>>
{
    public async Task<IEnumerable<DishDto>> Handle(GetDishesForRestaurantQuery request, CancellationToken cancellationToken)
    {
        var restaurant = await restaurantRepository.GetByIdAsync(request.RestaurantId);
        if (restaurant == null) throw new NotFoundException(nameof(Restaurant), request.RestaurantId.ToString());

        var dishes = mapper.Map<IEnumerable<DishDto>>(restaurant.Dishes);
        return dishes;
    }
}
