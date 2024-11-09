using AutoMapper;
using SwApi.Domain.Entities;

namespace SwApi.Application.Planets.Commands.DeletePlanet;

public class DeletePlanetProfile : Profile
{
    public DeletePlanetProfile()
    {
        CreateMap<DeletePlanetCommand, Planet>();
    }
}
