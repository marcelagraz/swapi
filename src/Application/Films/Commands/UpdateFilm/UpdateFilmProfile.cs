using AutoMapper;
using SwApi.Domain.Entities;

namespace SwApi.Application.Films.Commands.UpdateFilm;

public class UpdateFilmProfile : Profile
{
    public UpdateFilmProfile()
    {
        CreateMap<UpdateFilmCommand, Film>();
    }
}
