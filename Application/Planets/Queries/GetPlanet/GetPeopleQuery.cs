﻿using MediatR;
using SwApi.Domain.Entities;

namespace SwApi.Application.Planets.Commands.GetPlanet;

public record GetPlanetQuery : IRequest<Planet?>
{
    public Guid? Id { get; set; }
}
