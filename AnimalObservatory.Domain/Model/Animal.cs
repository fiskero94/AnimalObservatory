using AnimalObservatory.Domain.ValueObjects;

namespace AnimalObservatory.Domain.Model;

public class Animal
{
    public Guid Id { get; init; } = Guid.NewGuid();
    public required string Name { get; init; }
    public required string Species { get; init; }
    public required int Age { get; init; }
    public required double Height { get; init; }
    public required Position CurrentPosition { get; init; }
    public DateTimeOffset Created { get; init; } = DateTimeOffset.UtcNow;
    public DateTimeOffset LastUpdated { get; init; } = DateTimeOffset.UtcNow;
}
