using AnimalObservatory.Domain.ValueObjects;

namespace AnimalObservatory.Application.DataTransferObjects.Responses;

public class AnimalResponse
{
    public required Guid Id { get; init; }
    public required string Name { get; init; }
    public required string Species { get; init; }
    public required int Age { get; init; }
    public required double Height { get; init; }
    public required Position CurrentPosition { get; init; }
    public required DateTimeOffset Created { get; init; }
    public required DateTimeOffset LastUpdated { get; init; }
}
