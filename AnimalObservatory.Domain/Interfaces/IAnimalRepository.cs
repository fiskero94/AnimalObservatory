using AnimalObservatory.Domain.Model;

namespace AnimalObservatory.Domain.Interfaces;

/// <summary>
/// Repository for <see cref="Animal"/> data.
/// </summary>
public interface IAnimalRepository
{
    /// <summary>
    /// Get an animal by its identifier.
    /// </summary>
    /// <param name="id">The identifier of the animal to retrieve.</param>
    /// <returns>The <see cref="Animal"/> matching the specified <paramref name="id"/>.</returns>
    /// <exception cref="NotFoundException">Thrown when no <see cref="Animal"/> with the specified <paramref name="id"/> is found.</exception>
    Task<Animal> GetAnimalAsync(Guid id);

    /// <summary>
    /// Get a paginated list of animals.
    /// </summary>
    /// <param name="page">The page number to retrieve (1-based).</param>
    /// <param name="perPage">The number of <see cref="Animal"/> objects to retrieve per page.</param>
    /// <returns>A list of <see cref="Animal"/> objects from the specified <paramref name="page"/.</returns>
    Task<IEnumerable<Animal>> GetAnimalsAsync(int page, int perPage);

    /// <summary>
    /// Creates a new animal.
    /// </summary>
    /// <param name="animal">The <see cref="Animal"/> to create in the database.</param>
    /// <returns>The created <see cref="Animal"/> object.</returns>
    Task<Animal> CreateAnimalAsync(Animal animal);

    /// <summary>
    /// Updates an existing animal.
    /// </summary>
    /// <param name="animal">The <see cref="Animal"/> to update in the database.</param>
    /// <returns>The updated <see cref="Animal"/> object.</returns>
    /// <exception cref="NotFoundException">Thrown when no matching <see cref="Animal"/> is found.</exception>
    Task<Animal> UpdateAnimalAsync(Animal animal);

    /// <summary>
    /// Deletes an animal by its identifier.
    /// </summary>
    /// <param name="id">The identifier of the animal to delete.</param>
    /// <returns></returns>
    /// <exception cref="NotFoundException">Thrown when no <see cref="Animal"/> with the specified <paramref name="id"/> is found.</exception>
    Task DeleteAsync(Guid id);
}
