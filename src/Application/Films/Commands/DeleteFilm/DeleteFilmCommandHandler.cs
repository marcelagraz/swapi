using Ardalis.GuardClauses;
using AutoMapper;
using MediatR;
using SwApi.Application.Common.Repositories;

namespace SwApi.Application.Films.Commands.DeleteFilm;

public class DeleteFilmCommandHandler(
    IMapper mapper,
    IFilmRepository filmRepository) :
    IRequestHandler<DeleteFilmCommand>
{
    private readonly IMapper _mapper = mapper;
    private readonly IFilmRepository _filmRepository = filmRepository;

    public async Task Handle(DeleteFilmCommand command, CancellationToken cancellationToken)
    {
        Guard.Against.Null(command.Id);

        var film = await _filmRepository.FindAsync(command.Id.Value, cancellationToken);

        Guard.Against.Null(film);

        _mapper.Map(command, film);

        await _filmRepository.DeleteAsync(film, cancellationToken);
    }
}
