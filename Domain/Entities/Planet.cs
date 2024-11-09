using SwApi.Domain.Common;

namespace SwApi.Domain.Entities;

public class Planet : BaseEntity
{
    public required string Name { get; set; }

    public required float Gravity { get; set; }

    public required string Climate { get; set; }

    public List<People> Residents { get; set; } = [];

    public List<Film> Films { get; set; } = [];
}
