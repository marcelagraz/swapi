using AutoMapper;
using MediatR;
using SwApi.Application.Common.Repositories;
using SwApi.Domain.Entities;

namespace SwApi.Application.Peoples.Commands.UpdatePeople;

public class UpdatePeopleCommandHandler(
    IMapper mapper,
    IPeopleRepository peopleRepository) :
    IRequestHandler<UpdatePeopleCommand, Guid>
{
    private readonly IPeopleRepository peopleRepository = peopleRepository;

    public async Task<Guid> Handle(UpdatePeopleCommand command, CancellationToken cancellationToken)
    {
        var people = mapper.Map<People>(command);

        await peopleRepository.UpdateAsync(people, cancellationToken);

        return people.Id;
    }
}
