using Ardalis.GuardClauses;
using MediatR;
using SwApi.Application.Common.Repositories;

namespace SwApi.Application.Peoples.Commands.DeletePeople;

public class DeletePeopleCommandHandler(
    IPeopleRepository peopleRepository) :
    IRequestHandler<DeletePeopleCommand>
{
    private readonly IPeopleRepository peopleRepository = peopleRepository;

    public async Task Handle(DeletePeopleCommand command, CancellationToken cancellationToken)
    {
        Guard.Against.Null(command.Id);

        await peopleRepository.DeleteAsync(command.Id.Value, cancellationToken);
    }
}
