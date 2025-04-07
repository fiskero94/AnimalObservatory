using AnimalObservatory.Application.Mappers;
using AnimalObservatory.Application.Services;
using AnimalObservatory.Application.Validators;
using Microsoft.Extensions.DependencyInjection;

namespace AnimalObservatory.Application;

public static class DependencyInjection
{
    /// <summary>
    /// Adds the application layer to the service collection.
    /// </summary>
    /// <param name="services">The <see cref="IServiceCollection"/> to add the services to.</param>
    /// <returns>The given <see cref="IServiceCollection"/> instance</returns>
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddScoped<IAnimalValidator, AnimalValidator>();
        services.AddScoped<IAnimalMapper, AnimalMapper>();
        services.AddScoped<IAnimalService, AnimalService>();
        return services;
    }
}
