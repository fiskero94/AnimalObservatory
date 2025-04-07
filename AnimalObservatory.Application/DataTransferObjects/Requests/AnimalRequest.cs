using AnimalObservatory.Domain.ValueObjects;
using System.ComponentModel.DataAnnotations;

namespace AnimalObservatory.Application.DataTransferObjects.Requests;

public class AnimalRequest
{
    [StringLength(255)]
    public required string Name { get; set; }
    [StringLength(255)]
    public required string Species { get; set; }
    [Range(0, 1000)]
    public required int Age { get; set; }
    [Range(0, 1000)]
    public required double Height { get; set; }
    public required Position CurrentPosition { get; set; }
}
