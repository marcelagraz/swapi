using SwApi.Domain.Common;

namespace SwApi.Domain.Entities;

public class Starship : BaseEntity
{
    public required string Name { get; set; }

    public required string Model { get; set; }

    public required string StarshipClass { get; set; }

    public required string Manufacturer { get; set; }

    public required string CostInCredits { get; set; }

    public required string Length { get; set; }

    public required string Crew { get; set; }

    public required string Passengers { get; set; }

    public required string MaxAtmospheringSpeed { get; set; }

    public required string HyperdriveRating { get; set; }

    public required string MGLT { get; set; }

    public required string CargoCapacity { get; set; }

    public required string Consumables { get; set; }

    public List<Film> Films { get; set; } = [];

    public List<People> Pilots { get; set; } = [];
}
