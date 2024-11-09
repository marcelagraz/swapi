using AutoMapper;
using SwApi.Domain.Entities;

namespace SwApi.Application.Planets.Commands.UpdatePlanet;

public class UpdatePlanetProfile : Profile
{
    public UpdatePlanetProfile()
    {
        CreateMap<UpdatePlanetCommand, Planet>();
    }
}
