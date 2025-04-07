using AnimalObservatory.Application.DataTransferObjects.Requests;
using AnimalObservatory.Application.DataTransferObjects.Responses;
using Microsoft.AspNetCore.JsonPatch;

namespace AnimalObservatory.Application.Services;

/// <summary>
/// Service for managing <see cref="Animal"/> objects.
/// </summary>
public interface IAnimalService
{
    /// <summary>
    /// Get an <see cref="Animal"/> by its identifier.
    /// </summary>
    /// <param name="id">The identifier of the animal to retrieve.</param>
    /// <returns>An <see cref="AnimalResponse"/> matching the specified <paramref name="id"/>.</returns>
    public Task<AnimalResponse> GetAnimalAsync(Guid id);

    /// <summary>
    /// Get a paginated list of <see cref="Animal"/> objects.
    /// </summary>
    /// <param name="page">The page number to retrieve (1-based).</param>
    /// <param name="perPage">The number of <see cref="Animal"/> objects to retrieve per page.</param>
    /// <returns>A list of <see cref="Animal"/> objects from the specified <paramref name="page"/.</returns>
    public Task<IEnumerable<AnimalResponse>> GetAnimalsAsync(int? page, int? perPage);

    /// <summary>
    /// Creates a new <see cref="Animal"/>.
    /// </summary>
    /// <param name="request">The <see cref="AnimalRequest"/> to create the <see cref="Animal"/> from.</param>
    /// <returns>An <see cref="AnimalResponse"/> containing the created <see cref="Animal"/> properties.</returns>
    public Task<AnimalResponse> CreateAnimalAsync(AnimalRequest request);

    /// <summary>
    /// Updates an existing <see cref="Animal"/>.
    /// </summary>
    /// <param name="id">The identifier of the <see cref="Animal"/> to update.</param>
    /// <param name="request">The <see cref="AnimalRequest"/> to update the <see cref="Animal"/> with.</param>
    /// <returns>An <see cref="AnimalResponse"/> containing the updated <see cref="Animal"/> properties.</returns>
    public Task<AnimalResponse> UpdateAnimalAsync(Guid id, AnimalRequest request);

    /// <summary>
    /// Applies a patch to an existing <see cref="Animal"/>.
    /// </summary>
    /// <param name="id">The identifier of the <see cref="Animal"/> to update.</param>
    /// <param name="request">The <see cref="JsonPatchDocument"/> to update the <see cref="Animal"/> with.</param>
    /// <returns></returns>
    public Task<AnimalResponse> PatchAnimalAsync(Guid id, JsonPatchDocument<AnimalRequest> request);

    /// <summary>
    /// Deletes an <see cref="Animal"/> by its identifier.
    /// </summary>
    /// <param name="id">The identifier of the animal to delete.</param>
    /// <returns></returns>
    public Task DeleteAnimalAsync(Guid id);
}
