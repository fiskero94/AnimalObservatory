namespace AnimalObservatory.Domain.ValueObjects;

public readonly struct Position
{
    public double Latitude { get; init; }
    public double Longitude { get; init; }
    public double Altitude { get; init; }
}
