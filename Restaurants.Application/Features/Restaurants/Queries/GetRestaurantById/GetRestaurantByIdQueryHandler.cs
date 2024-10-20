using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Restaurants.Application.Features.Restaurants.Dtos;
using Restaurants.Domain.Exceptions;
using Restaurants.Domain.Respositories;


namespace Restaurants.Application.Features.Restaurants.Queries.GetRestaurantById
{
    internal class GetRestaurantByIdQueryHandler(ILogger<GetRestaurantByIdQueryHandler> logger,
        IMapper mapper,
        IRestaurantRepository restaurantRepository) : IRequestHandler<GetRestaurantByIdQuery, RestaurantDto>
    {
        public async Task<RestaurantDto> Handle(GetRestaurantByIdQuery request, CancellationToken cancellationToken)
        {
            logger.LogInformation("getting restaurant by id");
            var restaurant = await restaurantRepository.GetByIdAsync(request.Id)
                ?? throw new NotFoundException("Restaurant", request.Id.ToString());
            var restaurantDto = mapper.Map<RestaurantDto>(restaurant);
            return restaurantDto;
        }
    }
}
