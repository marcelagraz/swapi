using AutoMapper;
using MediatR;
using SwApi.Application.Common.Repositories;
using SwApi.Domain.Entities;

namespace SwApi.Application.Films.Commands.UpdateFilm;

public class UpdateFilmCommandHandler(
    IMapper mapper,
    IFilmRepository filmRepository) :
    IRequestHandler<UpdateFilmCommand, Film>
{
    private readonly IFilmRepository filmRepository = filmRepository;

    public async Task<Film> Handle(UpdateFilmCommand command, CancellationToken cancellationToken)
    {
        var film = mapper.Map<Film>(command);

        await filmRepository.UpdateAsync(film, cancellationToken);

        return film;
    }
}
