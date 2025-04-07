using AnimalObservatory.Domain.Exceptions;
using AnimalObservatory.Domain.Interfaces;
using AnimalObservatory.Domain.Model;
using AnimalObservatory.Infrastructure.DatabaseContexts;
using AnimalObservatory.Infrastructure.Entities;
using AnimalObservatory.Infrastructure.Mappers;
using Microsoft.EntityFrameworkCore;

namespace AnimalObservatory.Infrastructure.Repositories;

/// <summary>
/// Repository for <see cref="Animal"/> data.
/// </summary>
/// <param name="db">The database context used for data operations.</param>
/// <param name="mapper">The mapper instance used for entity conversions.</param>
internal class AnimalRepository(InMemoryContext db, IAnimalEntityMapper mapper) : IAnimalRepository
{
    /// <inheritdoc />
    public async Task<Animal> GetAnimalAsync(Guid id)
    {
        AnimalEntity animalEntity = await db.Animals.FindAsync(id) ??
            throw new NotFoundException();

        return mapper.MapToAnimal(animalEntity);
    }

    /// <inheritdoc />
    public async Task<IEnumerable<Animal>> GetAnimalsAsync(int page, int perPage)
    {
        return await db.Animals
            .OrderBy(a => a.Created)
            .Skip((page - 1) * perPage)
            .Take(perPage)
            .Select(a => mapper.MapToAnimal(a))
            .ToListAsync();
    }

    /// <inheritdoc />
    public async Task<Animal> CreateAnimalAsync(Animal animal)
    {
        AnimalEntity animalEntity = mapper.MapToAnimalEntity(animal);
        await db.Animals.AddAsync(animalEntity);
        await db.SaveChangesAsync();
        return mapper.MapToAnimal(animalEntity);
    }

    /// <inheritdoc />
    public async Task<Animal> UpdateAnimalAsync(Animal animal)
    {
        AnimalEntity animalEntity = await db.Animals.FindAsync(animal.Id) ??
            throw new NotFoundException();

        UpdateAnimalEntityProperties(animalEntity, animal);
        animalEntity.LastUpdated = DateTimeOffset.UtcNow;
        db.Animals.Update(animalEntity);
        await db.SaveChangesAsync();
        return mapper.MapToAnimal(animalEntity);
    }

    /// <inheritdoc />
    public async Task DeleteAsync(Guid id)
    {
        AnimalEntity animalEntity = await db.Animals.FindAsync(id) ??
            throw new NotFoundException();

        db.Animals.Remove(animalEntity);
        await db.SaveChangesAsync();
    }

    /// <summary>
    /// Updates the properties of an <see cref="AnimalEntity"/> based on the provided <see cref="Animal"/>.
    /// </summary>
    /// <param name="animalEntity">The <see cref="AnimalEntity"/> to update.</param>
    /// <param name="animal">The <see cref="Animal"/> to update from.</param>
    private static void UpdateAnimalEntityProperties(AnimalEntity animalEntity, Animal animal)
    {
        animalEntity.Name = animal.Name;
        animalEntity.Species = animal.Species;
        animalEntity.Age = animal.Age;
        animalEntity.Height = animal.Height;
        animalEntity.CurrentPosition = animal.CurrentPosition;
    }
}
