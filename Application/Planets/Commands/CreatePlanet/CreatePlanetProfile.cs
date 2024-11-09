using AutoMapper;
using SwApi.Domain.Entities;

namespace SwApi.Application.Planets.Commands.CreatePlanet;

public class CreatePlanetProfile : Profile
{
    public CreatePlanetProfile()
    {
        CreateMap<CreatePlanetCommand, Planet>();
    }
}
