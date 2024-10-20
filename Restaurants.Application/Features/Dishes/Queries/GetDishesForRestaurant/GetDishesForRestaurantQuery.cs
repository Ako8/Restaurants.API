using MediatR;
using Restaurants.Application.Features.Dishes.Dtos;


namespace Restaurants.Application.Features.Dishes.Queries.GetDishesForRestaurant;

public class GetDishesForRestaurantQuery(int restaurantId) : IRequest<IEnumerable<DishDto>>
{
    public int RestaurantId { get; } = restaurantId;
}
