using AnimalObservatory.Application.DataTransferObjects.Requests;
using AnimalObservatory.Application.DataTransferObjects.Responses;
using AnimalObservatory.Application.Mappers;
using AnimalObservatory.Application.Validators;
using AnimalObservatory.Domain.Interfaces;
using AnimalObservatory.Domain.Model;
using Microsoft.AspNetCore.JsonPatch;

namespace AnimalObservatory.Application.Services;

/// <summary>
/// Service for managing <see cref="Animal"/> objects.
/// </summary>
/// <param name="repository"></param>
/// <param name="validator"></param>
/// <param name="mapper"></param>
internal class AnimalService(
    IAnimalRepository repository,
    IAnimalValidator validator,
    IAnimalMapper mapper) : IAnimalService
{
    /// <inheritdoc />
    public async Task<AnimalResponse> GetAnimalAsync(Guid id)
    {
        Animal animal = await repository.GetAnimalAsync(id);
        return mapper.MapToResponse(animal);
    }

    /// <inheritdoc />
    public async Task<IEnumerable<AnimalResponse>> GetAnimalsAsync(int? page, int? perPage)
    {
        page = page != null ? Math.Max(page.Value, 1) : 1;
        perPage = perPage != null ? Math.Clamp(perPage.Value, 1, 100) : 1;
        IEnumerable<Animal> animals = await repository.GetAnimalsAsync(page.Value, perPage.Value);
        return animals.Select(mapper.MapToResponse);
    }

    /// <inheritdoc />
    public async Task<AnimalResponse> CreateAnimalAsync(AnimalRequest request)
    {
        validator.ValidateRequest(request);
        Animal animal = mapper.MapToAnimal(request);
        Animal createdAnimal = await repository.CreateAnimalAsync(animal);
        return mapper.MapToResponse(createdAnimal);
    }

    /// <inheritdoc />
    public async Task<AnimalResponse> UpdateAnimalAsync(Guid id, AnimalRequest request)
    {
        validator.ValidateRequest(request);
        Animal animal = await repository.GetAnimalAsync(id);
        Animal animalToUpdate = UpdateAnimalProperties(animal, request);
        Animal updatedAnimal = await repository.UpdateAnimalAsync(animalToUpdate);
        return mapper.MapToResponse(updatedAnimal);
    }

    /// <inheritdoc />
    public async Task<AnimalResponse> PatchAnimalAsync(Guid id, JsonPatchDocument<AnimalRequest> patch)
    {
        Animal animal = await repository.GetAnimalAsync(id);
        AnimalRequest request = mapper.MapToRequest(animal);
        patch.ApplyTo(request);
        validator.ValidateRequest(request);
        Animal animalToUpdate = UpdateAnimalProperties(animal, request);
        Animal updatedAnimal = await repository.UpdateAnimalAsync(animalToUpdate);
        return mapper.MapToResponse(updatedAnimal);
    }

    /// <inheritdoc />
    public async Task DeleteAnimalAsync(Guid id) =>
        await repository.DeleteAsync(id);

    /// <summary>
    /// Updates the properties of an existing animal with the values from the request.
    /// </summary>
    /// <param name="animal">The <see cref="Animal"/> to update.</param>
    /// <param name="request">The <see cref="AnimalRequest"/> to update from.</param>
    /// <returns>A new <see cref="Animal"/> with updated values.</returns>
    private static Animal UpdateAnimalProperties(Animal animal, AnimalRequest request) => new()
    {
        Id = animal.Id,
        Name = request.Name,
        Species = request.Species,
        Age = request.Age,
        Height = request.Height,
        CurrentPosition = request.CurrentPosition,
        Created = animal.Created,
        LastUpdated = DateTimeOffset.UtcNow
    };
}