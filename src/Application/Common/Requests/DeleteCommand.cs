using MediatR;

namespace SwApi.Application.Common.Requests;

public abstract record DeleteCommand : IRequest
{
    public Guid? Id { get; set; }

    public string? ConcurrencyStamp { get; set; }
}
