using AutoMapper;
using MediatR;
using SwApi.Application.Common.Repositories;
using SwApi.Domain.Entities;

namespace SwApi.Application.Films.Commands.CreateFilm;

public class CreateFilmCommandHandler(
    IMapper mapper,
    IFilmRepository filmRepository) :
    IRequestHandler<CreateFilmCommand, Guid>
{
    private readonly IFilmRepository filmRepository = filmRepository;

    public async Task<Guid> Handle(CreateFilmCommand command, CancellationToken cancellationToken)
    {
        var people = mapper.Map<Film>(command);

        await filmRepository.AddAsync(people, cancellationToken);

        return people.Id;
    }
}
