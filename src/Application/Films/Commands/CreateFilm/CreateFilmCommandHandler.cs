using AutoMapper;
using MediatR;
using SwApi.Application.Common.Repositories;
using SwApi.Domain.Entities;

namespace SwApi.Application.Films.Commands.CreateFilm;

public class CreateFilmCommandHandler(
    IMapper mapper,
    IFilmRepository filmRepository,
    TimeProvider timeProvider) :
    IRequestHandler<CreateFilmCommand, Film>
{
    private readonly IFilmRepository _filmRepository = filmRepository;
    private readonly TimeProvider _timeProvider = timeProvider;

    public async Task<Film> Handle(CreateFilmCommand command, CancellationToken cancellationToken)
    {
        var film = mapper.Map<Film>(command);

        var utcNow = _timeProvider.GetUtcNow().UtcDateTime.ToString("o");

        film.Created = utcNow;
        film.Edited = utcNow;

        await _filmRepository.AddAsync(film, cancellationToken);

        return film;
    }
}
