using SwApi.Domain.Common;

namespace SwApi.Domain.Entities;

public class People : BaseEntity
{
    public required string Name { get; set; }

    public required int BirthYear { get; set; }

    public required string Gender { get; set; }

    public List<Film> Films { get; set; } = [];

    public required Guid PlanetId { get; set; }

    public Planet? Planet { get; set; }
}
