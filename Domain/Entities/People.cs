namespace SwApi.Domain.Entities;

public class People
{
    public required string Name { get; set; }

    public required string BirthYear { get; set; }

    public required string EyeColor { get; set; }

    public required string Gender { get; set; }

    public required string HairColor { get; set; }

    public required string Height { get; set; }

    public required string Mass { get; set; }

    public required string SkinColor { get; set; }

    public required string Homeworld { get; set; }

    public List<Film> Films { get; set; } = [];

    public List<Specie> Species { get; set; } = [];

    public List<Starship> Starships { get; set; } = [];

    public List<Vehicle> Vehicles { get; set; } = [];

    public required string Created { get; set; }

    public required string Edited { get; set; }
}
