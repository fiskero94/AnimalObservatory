using AnimalObservatory.Domain.Model;
using AnimalObservatory.Infrastructure.Entities;

namespace AnimalObservatory.Infrastructure.Mappers;

/// <summary>
/// Maps between domain <see cref="Animal"/> objects and <see cref="AnimalEntity"/> objects.
/// </summary>
internal interface IAnimalEntityMapper
{
    /// <summary>
    /// Maps a domain <see cref="Animal"/> to an <see cref="AnimalEntity"/>.
    /// </summary>
    /// <param name="animal">The domain <see cref="Animal"/> object to map.</param>
    /// <returns>The resulting <see cref="AnimalEntity"/> object.</returns>
    public AnimalEntity MapToAnimalEntity(Animal animal);

    /// <summary>
    /// Maps an <see cref="AnimalEntity"/> to a domain <see cref="Animal"/>.
    /// </summary>
    /// <param name="animalEntity">The <see cref="AnimalEntity"/> object to map.</param>
    /// <returns>The resulting <see cref="Animal"/> object.</returns>
    public Animal MapToAnimal(AnimalEntity animalEntity);
}
