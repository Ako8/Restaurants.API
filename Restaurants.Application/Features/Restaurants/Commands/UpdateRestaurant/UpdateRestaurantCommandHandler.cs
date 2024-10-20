
using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Restaurants.Application.Features.Restaurants.Commands.DeleteRestaurant;
using Restaurants.Application.Features.Restaurants.Dtos;
using Restaurants.Domain.Entities;
using Restaurants.Domain.Exceptions;
using Restaurants.Domain.Interface;
using Restaurants.Domain.Respositories;
using Restaurants.Infrastructure.Authorization;

namespace Restaurants.Application.Features.Restaurants.Commands.UpdateRestaurant;

public class UpdateRestaurantCommandHandler(ILogger<DeleteRestaurantCommandHandler> logger,
    IRestaurantRepository restaurantRepository,
    IMapper mapper,
    IRestaurantAuthorizationService restaurantAuthorizationService) : IRequestHandler<UpdateRestaurantCommand>
{
    public async Task Handle(UpdateRestaurantCommand request, CancellationToken cancellationToken)
    {
        logger.LogInformation("updating restaurant with id");
        var restaurant = await restaurantRepository.GetByIdAsync(request.Id);
        if (restaurant is null) throw new NotFoundException("Restaurant", request.Id.ToString());

        if (!restaurantAuthorizationService.Authorize(restaurant, ResourceOperatoin.Update))
            throw new ForbidException();

        mapper.Map(request, restaurant);

        await restaurantRepository.SaveChanges();
    }
}
