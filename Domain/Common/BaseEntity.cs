namespace SwApi.Domain.Common;

public class BaseEntity
{
    public Guid? Id { get; set; }

    public string? Created { get; set; }

    public string? Edited { get; set; }

    public string? ConcurrencyStamp { get; set; } = Guid.NewGuid().ToString();
}
