namespace SwApi.Domain.Entities;

public class Planet
{
    public required string Name { get; set; }

    public required string Diameter { get; set; }

    public required string RotationPeriod { get; set; }

    public required string OrbitalPeriod { get; set; }

    public required string Gravity { get; set; }

    public required string Population { get; set; }

    public required string Climate { get; set; }

    public required string Terrain { get; set; }

    public required string SurfaceWater { get; set; }

    public List<People> Residents { get; set; } = [];

    public List<Film> Films { get; set; } = [];

    public required string Created { get; set; }

    public required string Edited { get; set; }
}
