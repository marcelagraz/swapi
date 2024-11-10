using Microsoft.AspNetCore.Mvc;
using SwApi.Api.Common;
using SwApi.Application.Planets.Commands.CreatePlanet;
using SwApi.Application.Planets.Commands.DeletePlanet;
using SwApi.Application.Planets.Commands.UpdatePlanet;
using SwApi.Application.Planets.Queries.GetAllPlanet;
using SwApi.Application.Planets.Queries.GetPlanet;
using SwApi.Domain.Entities;

namespace SwApi.Api.Controllers;

public class PlanetsController : BaseController
{
    [HttpGet]
    public async Task<ActionResult<List<Planet>>> GetAll(int? pageNumber, int? pageSize, CancellationToken cancellationToken) =>
        await Sender.Send(new GetAllPlanetQuery { PageNumber = pageNumber, PageSize = pageSize }, cancellationToken);

    [HttpGet("{id}")]
    public async Task<ActionResult<Planet?>> Get(Guid? id, CancellationToken cancellationToken) =>
        await Sender.Send(new GetPlanetQuery { Id = id }, cancellationToken);

    [HttpPost]
    public async Task<ActionResult<Planet?>> Create(CreatePlanetCommand command, CancellationToken cancellationToken) =>
        await Sender.Send(command, cancellationToken);

    [HttpPut("{id}")]
    public async Task<ActionResult<Planet?>> Update(UpdatePlanetCommand command, CancellationToken cancellationToken) =>
        await Sender.Send(command, cancellationToken);

    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(DeletePlanetCommand command, CancellationToken cancellationToken)
    {
        await Sender.Send(command, cancellationToken);
        return Ok();
    }
}
