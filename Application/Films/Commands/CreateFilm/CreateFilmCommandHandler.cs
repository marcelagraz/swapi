using AutoMapper;
using MediatR;
using SwApi.Application.Common.Repositories;
using SwApi.Domain.Entities;

namespace SwApi.Application.Films.Commands.CreateFilm;

public class CreateFilmCommandHandler(
    IMapper mapper,
    IFilmRepository filmRepository) :
    IRequestHandler<CreateFilmCommand, Film>
{
    private readonly IFilmRepository filmRepository = filmRepository;

    public async Task<Film> Handle(CreateFilmCommand command, CancellationToken cancellationToken)
    {
        var film = mapper.Map<Film>(command);

        await filmRepository.AddAsync(film, cancellationToken);

        return film;
    }
}
