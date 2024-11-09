using AutoMapper;
using MediatR;
using SwApi.Application.Common.Repositories;
using SwApi.Domain.Entities;

namespace SwApi.Application.Films.Commands.DeleteFilm;

public class DeleteFilmCommandHandler(
    IMapper mapper,
    IFilmRepository filmRepository) :
    IRequestHandler<DeleteFilmCommand, Guid>
{
    private readonly IFilmRepository filmRepository = filmRepository;

    public async Task<Guid> Handle(DeleteFilmCommand command, CancellationToken cancellationToken)
    {
        var people = mapper.Map<Film>(command);

        await filmRepository.DeleteAsync(people, cancellationToken);

        return people.Id;
    }
}
