namespace SwApi.Domain.Common;

public class BaseEntity
{
    public Guid Id { get; set; }

    public required string Created { get; set; }

    public required string Edited { get; set; }

    public required string ConcurrencyStamp { get; set; } = Guid.NewGuid().ToString();
}
