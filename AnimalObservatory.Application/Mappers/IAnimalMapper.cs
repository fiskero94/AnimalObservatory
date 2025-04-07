using AnimalObservatory.Application.DataTransferObjects.Requests;
using AnimalObservatory.Application.DataTransferObjects.Responses;
using AnimalObservatory.Domain.Model;

namespace AnimalObservatory.Application.Mappers;

/// <summary>
/// Mapper for converting between <see cref="Animal"/> and its data transfer objects.
/// </summary>
internal interface IAnimalMapper
{
    /// <summary>
    /// Maps an <see cref="Animal"/> to an <see cref="AnimalRequest"/> object.
    /// </summary>
    /// <param name="animal">The domain <see cref="Animal"/> object to map from.</param>
    /// <returns>A <see cref="AnimalRequest"/> object containing the properties of the given domain <see cref="Animal"/>.</returns>
    public AnimalRequest MapToRequest(Animal animal);

    /// <summary>
    /// Maps an <see cref="Animal"/> to an <see cref="AnimalResponse"/> object.
    /// </summary>
    /// <param name="animal">The domain <see cref="Animal"/> object to map from.</param>
    /// <returns>A <see cref="AnimalResponse"/> object containing the properties of the given domain <see cref="Animal"/>.</returns>
    public AnimalResponse MapToResponse(Animal animal);

    /// <summary>
    /// Maps an <see cref="AnimalRequest"/> to an <see cref="Animal"/> object.
    /// </summary>
    /// <param name="request">The <see cref="AnimalRequest"/> object to map from.</param>
    /// <returns>A domain <see cref="Animal"/> object containing the properties of the given <see cref="AnimalRequest"/>.</returns>
    public Animal MapToAnimal(AnimalRequest request);
}
