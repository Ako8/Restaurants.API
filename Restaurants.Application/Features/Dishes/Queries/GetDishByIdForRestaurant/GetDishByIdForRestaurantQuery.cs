using MediatR;
using Restaurants.Application.Features.Dishes.Dtos;

namespace Restaurants.Application.Features.Dishes.Queries.GetDishByIdForRestaurant;

public class GetDishByIdForRestaurantQuery(int restaurantId, int dishId) : IRequest<DishDto>
{
    public int DishId { get; } = dishId;
    public int RestaurantId { get; } = restaurantId;

}
