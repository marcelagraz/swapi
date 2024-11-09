using SwApi.Domain.Common;

namespace SwApi.Domain.Entities;

public class People : BaseEntity
{
    public string? Name { get; set; }

    public int? BirthYear { get; set; }

    public string? Gender { get; set; }

    public List<int> Films { get; set; } = [];

    public Guid? PlanetId { get; set; }

    public Planet? Planet { get; set; }
}
