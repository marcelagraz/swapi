using Ardalis.GuardClauses;
using MediatR;
using SwApi.Application.Common.Repositories;
using SwApi.Application.Common.Requests;

namespace SwApi.Application.Films.Commands.DeleteFilm;

public class DeleteFilmCommandHandler(
    IFilmRepository filmRepository) :
    IRequestHandler<DeleteCommand>
{
    private readonly IFilmRepository filmRepository = filmRepository;

    public async Task Handle(DeleteCommand command, CancellationToken cancellationToken)
    {
        Guard.Against.Null(command.Id);

        await filmRepository.DeleteAsync(command.Id.Value, cancellationToken);
    }
}
