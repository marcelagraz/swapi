using SwApi.Domain.Common;

namespace SwApi.Domain.Entities;

public class Planet : BaseEntity
{
    public string? Name { get; set; }

    public float? Gravity { get; set; }

    public string? Climate { get; set; }

    public List<People> Residents { get; set; } = [];

    public List<Film> Films { get; set; } = [];
}
