using SwApi.Domain.Common;

namespace SwApi.Domain.Entities;

public class People : BaseEntity
{
    public string? Name { get; set; }

    public string? BirthYear { get; set; }

    public string? Gender { get; set; }

    public List<Film> Films { get; set; } = [];

    public Guid? HomeworldId { get; set; }

    public Planet? Homeworld { get; set; }
}
