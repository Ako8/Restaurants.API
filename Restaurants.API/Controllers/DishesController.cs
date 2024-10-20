using MediatR;
using Microsoft.AspNetCore.Mvc;
using Restaurants.Application.Features.Dishes.Commands.DeleteDishForRestaurant;
using Restaurants.Application.Features.Dishes.Queries.GetDishesForRestaurant;
using Restaurants.Application.Features.Dishes.Queries.GetDishByIdForRestaurant;
using Restaurants.Application.Features.Dishes.Commands.CreateDish;
using Microsoft.AspNetCore.Authorization;
using Restaurants.Infrastructure.Authorization;
namespace Restaurants.API.Controllers
{
    [Route("api/restaurants/{restaurantId}/dishes")]
    [ApiController]
    [Authorize]
    public class DishesController(IMediator mediator) : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> CreateDish([FromRoute] int restaurantId, CreateDishCommand command)
        {
            command.RestaurantId = restaurantId;
            var dishId = await mediator.Send(command);
            return CreatedAtAction(nameof(GetByIdForRestaurant), new { restaurantId, dishId }, null);
        }

        [HttpGet]
        [Authorize(Policy = PolicyNames.AtLeast20)]
        public async Task<IActionResult> GetAllForRestaurant([FromRoute] int restaurantId)
        {
            var dishes = await mediator.Send(new GetDishesForRestaurantQuery(restaurantId));
            return Ok(dishes);
        }

        [HttpGet("{dishId}")]
        public async Task<IActionResult> GetByIdForRestaurant([FromRoute] int restaurantId, [FromRoute] int dishId)
        {
            var dish = await mediator.Send(new GetDishByIdForRestaurantQuery(restaurantId, dishId));
            return Ok(dish);
        }

        [HttpDelete("{dishId}")]
        public async Task<IActionResult> DeleteForRestaurant([FromRoute] int restaurantId, [FromRoute] int dishId)
        {
            await mediator.Send(new DeleteDishForRestaurantCommand(restaurantId, dishId));
            return NoContent();
        }

    }
}
