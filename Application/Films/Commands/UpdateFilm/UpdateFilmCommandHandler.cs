using AutoMapper;
using MediatR;
using SwApi.Application.Common.Repositories;
using SwApi.Domain.Entities;

namespace SwApi.Application.Films.Commands.UpdateFilm;

public class UpdateFilmCommandHandler(
    IMapper mapper,
    IFilmRepository filmRepository) :
    IRequestHandler<UpdateFilmCommand, Guid>
{
    private readonly IFilmRepository filmRepository = filmRepository;

    public async Task<Guid> Handle(UpdateFilmCommand command, CancellationToken cancellationToken)
    {
        var people = mapper.Map<Film>(command);

        await filmRepository.UpdateAsync(people, cancellationToken);

        return people.Id;
    }
}
