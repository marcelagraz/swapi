using AutoMapper;
using MediatR;
using SwApi.Application.Common.Repositories;
using SwApi.Domain.Entities;

namespace SwApi.Application.Peoples.Commands.CreatePeople;

public class CreatePeopleCommandHandler(
    IMapper mapper,
    IPeopleRepository peopleRepository) :
    IRequestHandler<CreatePeopleCommand, People>
{
    private readonly IPeopleRepository peopleRepository = peopleRepository;

    public async Task<People> Handle(CreatePeopleCommand command, CancellationToken cancellationToken)
    {
        var people = mapper.Map<People>(command);

        await peopleRepository.AddAsync(people, cancellationToken);

        return people;
    }
}
