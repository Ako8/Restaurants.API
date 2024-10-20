using AutoMapper;
using Restaurants.Application.Features.Dishes.Commands.CreateDish;
using Restaurants.Domain.Entities;
namespace Restaurants.Application.Features.Dishes.Dtos;

public class DishesProfile : Profile
{
    public DishesProfile()
    {
        CreateMap<CreateDishCommand, Dish>();
        CreateMap<CreateDishDto, Dish>();
        CreateMap<Dish, DishDto>();
    }
}
