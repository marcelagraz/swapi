using Ardalis.GuardClauses;
using AutoMapper;
using MediatR;
using SwApi.Application.Common.Repositories;
using SwApi.Domain.Entities;

namespace SwApi.Application.Films.Commands.UpdateFilm;

public class UpdateFilmCommandHandler(
    IMapper mapper,
    IFilmRepository filmRepository,
    TimeProvider timeProvider) :
    IRequestHandler<UpdateFilmCommand, Film>
{
    private readonly IFilmRepository _filmRepository = filmRepository;
    private readonly TimeProvider _timeProvider = timeProvider;

    public async Task<Film> Handle(UpdateFilmCommand command, CancellationToken cancellationToken)
    {
        Guard.Against.Null(command.Id);

        var film = await _filmRepository.FindAsync(command.Id.Value, cancellationToken);

        Guard.Against.Null(film);

        mapper.Map(command, film);

        film.Edited = _timeProvider.GetUtcNow().UtcDateTime.ToString("o");

        await _filmRepository.UpdateAsync(film, cancellationToken);

        return film;
    }
}
