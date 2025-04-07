using AnimalObservatory.Application.DataTransferObjects.Requests;

namespace AnimalObservatory.Application.Validators;

/// <summary>
/// Interface for animal validation.
/// </summary>
internal interface IAnimalValidator
{
    /// <summary>
    /// Validates the given animal request.
    /// </summary>
    /// <param name="request">The <see cref="AnimalRequest"/> to validate.</param>
    /// <exception cref="ValidationException">Thrown if the given <see cref="AnimalRequest"/> fails validation.</exception>
    public void ValidateRequest(AnimalRequest request);
}
