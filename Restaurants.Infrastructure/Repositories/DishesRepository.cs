using Microsoft.EntityFrameworkCore;
using Restaurants.Domain.Entities;
using Restaurants.Domain.Respositories;
using Restaurants.Infrastructure.Persistence;

namespace Restaurants.Infrastructure.Repositories;

internal class DishesRepository(RestaurantsDbContext DbContext) : IDishesRepository
{
    public async Task<int> Create(Dish  dish)
    {
        DbContext.Dishes.Add(dish);
        await DbContext.SaveChangesAsync();
        return dish.Id;
    }

    public async Task Delete(Dish dish)
    {
        DbContext.Remove(dish);
        await DbContext.SaveChangesAsync();
    }
}
