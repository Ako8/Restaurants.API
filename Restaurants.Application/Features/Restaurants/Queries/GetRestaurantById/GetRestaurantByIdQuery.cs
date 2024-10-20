
using MediatR;
using Restaurants.Application.Features.Restaurants.Dtos;

namespace Restaurants.Application.Features.Restaurants.Queries.GetRestaurantById;

public class GetRestaurantByIdQuery(int id) : IRequest<RestaurantDto>
{
    public int Id { get; } = id;
}
