using AnimalObservatory.Domain.ValueObjects;

namespace AnimalObservatory.Infrastructure.Entities;

internal class AnimalEntity
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public required string Name { get; set; }
    public required string Species { get; set; }
    public required int Age { get; set; }
    public required double Height { get; set; }
    public required Position CurrentPosition { get; set; }
    public DateTimeOffset Created { get; set; } = DateTimeOffset.UtcNow;
    public DateTimeOffset LastUpdated { get; set; } = DateTimeOffset.UtcNow;
}
