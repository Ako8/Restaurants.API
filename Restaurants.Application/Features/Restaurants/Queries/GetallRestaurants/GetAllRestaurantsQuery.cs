using MediatR;
using Restaurants.Application.Features.Restaurants.Dtos;

namespace Restaurants.Application.Features.Restaurants.Queries.GetallRestaurants;

public class GetAllRestaurantsQuery : IRequest<IEnumerable<RestaurantDto>>
{
}
