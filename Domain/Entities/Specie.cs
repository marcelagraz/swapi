namespace SwApi.Domain.Entities;

public class Specie
{
    public required string Name { get; set; }

    public required string Classification { get; set; }

    public required string Designation { get; set; }

    public required string AverageHeight { get; set; }

    public required string AverageLifespan { get; set; }

    public required string EyeColors { get; set; }

    public required string HairColors { get; set; }

    public required string SkinColors { get; set; }

    public required string Language { get; set; }

    public required string Homeworld { get; set; }

    public List<People> People { get; set; } = [];

    public List<Film> Films { get; set; } = [];

    public required string Created { get; set; }

    public required string Edited { get; set; }
}
