using Ardalis.GuardClauses;
using AutoMapper;
using MediatR;
using SwApi.Application.Common.Repositories;
using SwApi.Domain.Entities;
using System;

namespace SwApi.Application.Peoples.Commands.UpdatePeople;

public class UpdatePeopleCommandHandler(
    IMapper mapper,
    IPeopleRepository peopleRepository,
    TimeProvider timeProvider) :
    IRequestHandler<UpdatePeopleCommand, People>
{
    private readonly IPeopleRepository _peopleRepository = peopleRepository;
    private readonly TimeProvider _timeProvider = timeProvider;

    public async Task<People> Handle(UpdatePeopleCommand command, CancellationToken cancellationToken)
    {
        Guard.Against.Null(command.Id);

        var people = await _peopleRepository.FindAsync(command.Id.Value, cancellationToken);

        Guard.Against.Null(people);

        mapper.Map(command, people);

        people.Edited = _timeProvider.GetUtcNow().UtcDateTime.ToString("o");

        await peopleRepository.UpdateAsync(people, cancellationToken);

        return people;
    }
}
