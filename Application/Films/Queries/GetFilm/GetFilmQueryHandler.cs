using Ardalis.GuardClauses;
using MediatR;
using SwApi.Application.Common.Repositories;
using SwApi.Domain.Entities;

namespace SwApi.Application.Films.Commands.GetFilm;

public class GetFilmQueryHandler(
    IFilmRepository filmRepository) :
    IRequestHandler<GetFilmQuery, Film?>
{
    private readonly IFilmRepository filmRepository = filmRepository;

    public async Task<Film?> Handle(GetFilmQuery query, CancellationToken cancellationToken)
    {
        Guard.Against.Null(query.Id);

        var film = await filmRepository.FindAsync(query.Id.Value, cancellationToken);

        return film;
    }
}
