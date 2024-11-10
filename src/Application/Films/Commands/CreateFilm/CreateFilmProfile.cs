using AutoMapper;
using SwApi.Domain.Entities;

namespace SwApi.Application.Films.Commands.CreateFilm;

public class CreateFilmProfile : Profile
{
    public CreateFilmProfile()
    {
        CreateMap<CreateFilmCommand, Film>();
    }
}
