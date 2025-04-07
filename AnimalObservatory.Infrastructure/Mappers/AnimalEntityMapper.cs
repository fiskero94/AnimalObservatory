using AnimalObservatory.Domain.Model;
using AnimalObservatory.Infrastructure.Entities;

namespace AnimalObservatory.Infrastructure.Mappers;

/// <inheritdoc />
internal class AnimalEntityMapper : IAnimalEntityMapper
{
    /// <inheritdoc />
    public AnimalEntity MapToAnimalEntity(Animal animal) => new()
    {
        Id = animal.Id,
        Name = animal.Name,
        Species = animal.Species,
        Age = animal.Age,
        Height = animal.Height,
        CurrentPosition = animal.CurrentPosition,
        Created = animal.Created,
        LastUpdated = animal.LastUpdated
    };

    /// <inheritdoc />
    public Animal MapToAnimal(AnimalEntity animalEntity) => new()
    {
        Id = animalEntity.Id,
        Name = animalEntity.Name,
        Species = animalEntity.Species,
        Age = animalEntity.Age,
        Height = animalEntity.Height,
        CurrentPosition = animalEntity.CurrentPosition,
        Created = animalEntity.Created,
        LastUpdated = animalEntity.LastUpdated
    };
}
