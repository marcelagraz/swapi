using Ardalis.GuardClauses;
using AutoMapper;
using MediatR;
using SwApi.Application.Common.Repositories;

namespace SwApi.Application.Peoples.Commands.DeletePeople;

public class DeletePeopleCommandHandler(
    IMapper mapper,
    IPeopleRepository peopleRepository) :
    IRequestHandler<DeletePeopleCommand>
{
    private readonly IMapper _mapper = mapper;
    private readonly IPeopleRepository _peopleRepository = peopleRepository;

    public async Task Handle(DeletePeopleCommand command, CancellationToken cancellationToken)
    {
        Guard.Against.Null(command.Id);

        var people = await _peopleRepository.FindAsync(command.Id.Value, cancellationToken);

        Guard.Against.Null(people);

        _mapper.Map(command, people);

        await _peopleRepository.DeleteAsync(people, cancellationToken);
    }
}
