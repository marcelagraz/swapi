using AutoMapper;
using MediatR;
using SwApi.Application.Common.Repositories;
using SwApi.Domain.Entities;
using System.Numerics;

namespace SwApi.Application.Peoples.Commands.CreatePeople;

public class CreatePeopleCommandHandler(
    IMapper mapper,
    IPeopleRepository peopleRepository,
    TimeProvider timeProvider) :
    IRequestHandler<CreatePeopleCommand, People>
{
    private readonly IPeopleRepository _peopleRepository = peopleRepository;
    private readonly TimeProvider _timeProvider = timeProvider;

    public async Task<People> Handle(CreatePeopleCommand command, CancellationToken cancellationToken)
    {
        var people = mapper.Map<People>(command);

        var utcNow = _timeProvider.GetUtcNow().UtcDateTime.ToString("o");

        people.Created = utcNow;
        people.Edited = utcNow;

        await _peopleRepository.AddAsync(people, cancellationToken);

        return people;
    }
}
