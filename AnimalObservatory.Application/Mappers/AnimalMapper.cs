using AnimalObservatory.Application.DataTransferObjects.Requests;
using AnimalObservatory.Application.DataTransferObjects.Responses;
using AnimalObservatory.Domain.Model;

namespace AnimalObservatory.Application.Mappers;

/// <inheritdoc />
internal class AnimalMapper : IAnimalMapper
{
    /// <inheritdoc />
    public AnimalRequest MapToRequest(Animal animal) => new()
    {
        Name = animal.Name,
        Species = animal.Species,
        Age = animal.Age,
        Height = animal.Height,
        CurrentPosition = animal.CurrentPosition
    };

    /// <inheritdoc />
    public AnimalResponse MapToResponse(Animal animal) => new()
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
    public Animal MapToAnimal(AnimalRequest request) => new()
    {
        Name = request.Name,
        Species = request.Species,
        Age = request.Age,
        Height = request.Height,
        CurrentPosition = request.CurrentPosition
    };
}
