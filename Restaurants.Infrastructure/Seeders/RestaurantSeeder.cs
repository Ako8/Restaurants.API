using Restaurants.Infrastructure.Persistence;
using Restaurants.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Restaurants.Domain.Constants;

namespace Restaurants.Infrastructure.Seeders
{
    internal class RestaurantSeeder(RestaurantsDbContext dbContext) : IRestaurantSeeder
    {
        public async Task Seed()
        {
            if (await dbContext.Database.CanConnectAsync())
            {
                if (!dbContext.Restaurants.Any())
                {
                    var restaurants = GetRestaurants();
                    dbContext.Restaurants.AddRange(restaurants);
                    await dbContext.SaveChangesAsync();
                }

                if (!dbContext.Roles.Any())
                {
                    var roles = GetRoles();
                    dbContext.Roles.AddRange(roles);
                    await dbContext.SaveChangesAsync();
                }
            }
        }

        private IEnumerable<IdentityRole> GetRoles()
        {
            List<IdentityRole> roles =
                [
                    new (UserRoles.User){
                        NormalizedName = UserRoles.User.ToUpper(),
                    },
                    new (UserRoles.Owner){
                        NormalizedName = UserRoles.Owner.ToUpper()
                    },
                    new (UserRoles.Admin){
                        NormalizedName = UserRoles.Admin.ToUpper()
                    }

                ];
            return roles;
        }


        private IEnumerable<Restaurant> GetRestaurants()
        {
            List<Restaurant> restaurants = [
                new()
                {
                    ContactNumber = "423424242342",
                    Name = "KFC",
                    Category = "Fast Food",
                    Description = "short for kentucky fried Chiken",
                    ContactEmail = "contaxxt@gmail.com",
                    HasDelivery = true,
                    Dishes =
                    [
                        new()
                        {
                            Name = "Hot Chicken",
                            Description = "10pcs. idk",
                            Price = 19.39M,
                        },
                        new()
                        {
                            Name = "Hot",
                            Description = "idk",
                            Price = 1.39M,
                        }
                    ],
                    Address = new()
                    { 

                        City = "London",
                        Street = "Clock St 5",
                        PostalCode = "1100",
                    }
                },
                new Restaurant()
                {
                    ContactNumber = "54345345",
                    Name = "KFC99",
                    Category = "Fast Foo99d",
                    Description = "short for kentucky fried Chiken999",
                    ContactEmail = "contaxxt@gmail.com99",
                    HasDelivery = true,
                    Dishes =
                    [
                        new()
                        {
                            Name = "Hot Chicken99",
                            Description = "10pcs. idk9",
                            Price = 19.39M,
                        },
                        new()
                        {
                            Name = "Hot9",
                            Description = "idk9",
                            Price = 199.39M,
                        }
                    ],
                    Address = new()
                    {
                        City = "London99",
                        Street = "Clock St 995",
                        PostalCode = "110990",
                    }
                }
                ];

            return restaurants;
        }
    }
}
