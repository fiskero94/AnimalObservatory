using AnimalObservatory.Domain.Interfaces;
using AnimalObservatory.Infrastructure.DatabaseContexts;
using AnimalObservatory.Infrastructure.Mappers;
using AnimalObservatory.Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace AnimalObservatory.Infrastructure;

public static class DependencyInjection
{
    /// <summary>
    /// Adds the infrastructure layer to the service collection.
    /// </summary>
    /// <param name="services">The <see cref="IServiceCollection"/> to add the services to.</param>
    /// <returns>The given <see cref="IServiceCollection"/> instance</returns>
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        services.AddDbContext<InMemoryContext>();
        services.AddScoped<IAnimalEntityMapper, AnimalEntityMapper>();
        services.AddScoped<IAnimalRepository, AnimalRepository>();
        return services;
    }
}
