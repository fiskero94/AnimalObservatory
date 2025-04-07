using AnimalObservatory.Application.DataTransferObjects.Requests;
using System.ComponentModel.DataAnnotations;

namespace AnimalObservatory.Application.Validators;

/// <inheritdoc />
internal class AnimalValidator : IAnimalValidator
{
    /// <inheritdoc />
    public void ValidateRequest(AnimalRequest request)
    {
        ValidationContext context = new(request);
        Validator.ValidateObject(request, context);
    }
}
