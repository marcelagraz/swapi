using Ardalis.GuardClauses;
using MediatR;
using SwApi.Application.Common.Repositories;

namespace SwApi.Application.Films.Commands.DeleteFilm;

public class DeletePlanetCommandHandler(
    IFilmRepository filmRepository) :
    IRequestHandler<DeleteFilmCommand>
{
    private readonly IFilmRepository _filmRepository = filmRepository;

    public async Task Handle(DeleteFilmCommand command, CancellationToken cancellationToken)
    {
        Guard.Against.Null(command.Id);

        await _filmRepository.DeleteAsync(command.Id.Value, cancellationToken);
    }
}
