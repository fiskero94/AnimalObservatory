using AnimalObservatory.Application.DataTransferObjects.Requests;
using AnimalObservatory.Application.DataTransferObjects.Responses;
using AnimalObservatory.Application.Services;
using AnimalObservatory.Domain.Exceptions;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace AnimalObservatory.Presentation.Controllers;

[ApiController]
[Route("animals")]
public class AnimalController(IAnimalService animalService) : ControllerBase
{
    [HttpGet("{id}", Name = "GetAnimal")]
    [ProducesResponseType(typeof(AnimalResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetAnimalAsync(Guid id)
    {
        try
        {
            AnimalResponse response = await animalService.GetAnimalAsync(id);
            return Ok(response);
        }
        catch (NotFoundException)
        {
            return AnimalNotFound(id);
        }
    }

    [HttpGet(Name = "GetAnimals")]
    [ProducesResponseType(typeof(IEnumerable<AnimalResponse>), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetAnimalsAsync([FromQuery] int? page, [FromQuery] int? perPage)
    {
        IEnumerable<AnimalResponse> responses = await animalService.GetAnimalsAsync(page, perPage);
        return Ok(responses);
    }

    [HttpPost(Name = "CreateAnimal")]
    [ProducesResponseType(typeof(AnimalResponse), StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> CreateAnimalAsync([FromBody] AnimalRequest request)
    {
        AnimalResponse response = await animalService.CreateAnimalAsync(request);
        return CreatedAtRoute("GetAnimal", new { id = response.Id }, response);
    }

    [HttpPut("{id}", Name = "UpdateAnimal")]
    [ProducesResponseType(typeof(AnimalResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> UpdateAnimalAsync(Guid id, [FromBody] AnimalRequest request)
    {
        try
        {
            AnimalResponse response = await animalService.UpdateAnimalAsync(id, request);
            return Ok(response);
        }
        catch (NotFoundException)
        {
            return AnimalNotFound(id);
        }
    }

    [HttpPatch("{id}", Name = "PatchAnimal")]
    [ProducesResponseType(typeof(AnimalResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> PatchAnimalAsync(Guid id, [FromBody] JsonPatchDocument<AnimalRequest> request)
    {
        try
        {
            AnimalResponse response = await animalService.PatchAnimalAsync(id, request);
            return Ok(response);
        }
        catch (NotFoundException)
        {
            return AnimalNotFound(id);
        }
    }

    [HttpDelete("{id}", Name = "DeleteAnimal")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> DeleteAnimalAsync(Guid id)
    {
        try
        {
            await animalService.DeleteAnimalAsync(id);
            return NoContent();
        }
        catch (NotFoundException)
        {
            return AnimalNotFound(id);
        }
    }

    private NotFoundObjectResult AnimalNotFound(Guid id) =>
        NotFound(new { Message = $"Animal {id} not found" });
}
