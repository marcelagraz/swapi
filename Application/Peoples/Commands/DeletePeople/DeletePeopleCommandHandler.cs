using AutoMapper;
using MediatR;
using SwApi.Application.Common.Repositories;
using SwApi.Domain.Entities;

namespace SwApi.Application.Peoples.Commands.DeletePeople;

public class DeletePeopleCommandHandler(
    IMapper mapper,
    IPeopleRepository peopleRepository) :
    IRequestHandler<DeletePeopleCommand, Guid>
{
    private readonly IPeopleRepository peopleRepository = peopleRepository;

    public async Task<Guid> Handle(DeletePeopleCommand command, CancellationToken cancellationToken)
    {
        var people = mapper.Map<People>(command);

        await peopleRepository.DeleteAsync(people, cancellationToken);

        return people.Id;
    }
}
