using Microsoft.Extensions.DependencyInjection;
using Restaurants.Application.Features.Users;

namespace Restaurants.Application.Extensions;

public static class ServiceCollectionExtensions
{
    public static void AddApplication(this IServiceCollection services)
    {
        var applicationAssembly = typeof(ServiceCollectionExtensions).Assembly;
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(applicationAssembly));
        services.AddAutoMapper(applicationAssembly);

        services.AddScoped<IUserContext, UserContext>();

        services.AddHttpContextAccessor();  
    }
}
