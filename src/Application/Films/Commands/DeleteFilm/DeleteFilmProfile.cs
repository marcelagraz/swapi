using AutoMapper;
using SwApi.Domain.Entities;

namespace SwApi.Application.Films.Commands.DeleteFilm;

public class DeleteFilmProfile : Profile
{
    public DeleteFilmProfile()
    {
        CreateMap<DeleteFilmCommand, Film>();
    }
}
