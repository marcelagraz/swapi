namespace SwApi.Api.Common.Responses;

public class ValidationError
{
    public required string Field { get; set; }

    public List<string> Messages { get; set; } = [];
}
