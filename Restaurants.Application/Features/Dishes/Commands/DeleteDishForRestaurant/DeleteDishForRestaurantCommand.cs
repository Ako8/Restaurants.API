using MediatR;

namespace Restaurants.Application.Features.Dishes.Commands.DeleteDishForRestaurant;

public class DeleteDishForRestaurantCommand(int restaurantId, int dishId) : IRequest
{
    public int DishId { get; set; } = dishId;
    public int RestaurantId { get; set; } = restaurantId;
}
