using Microsoft.AspNetCore.Mvc;
using SwApi.Api.Common.Controllers;
using SwApi.Api.Common.Responses;
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
    public async Task<ActionResult<List<Planet>>> GetAll(int? pageNumber, int? pageSize, CancellationToken cancellationToken)
    {
        var planets = await Sender.Send(new GetAllPlanetQuery { PageNumber = pageNumber, PageSize = pageSize }, cancellationToken);

        var response = new BaseResponse<List<Planet>> { Data = planets };

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Planet?>> Get(Guid? id, CancellationToken cancellationToken)
    {
        var planet = await Sender.Send(new GetPlanetQuery { Id = id }, cancellationToken);

        var response = new BaseResponse<Planet> { Data = planet };

        return Ok(response);
    }

    [HttpPost]
    public async Task<ActionResult<Planet?>> Create(CreatePlanetCommand command, CancellationToken cancellationToken)
    {
        var planet = await Sender.Send(command, cancellationToken);

        var response = new BaseResponse<Planet> { Data = planet };

        return Created(response);
    }

    [HttpPut]
    public async Task<ActionResult<Planet?>> Update(UpdatePlanetCommand command, CancellationToken cancellationToken)
    {
        var planet = await Sender.Send(command, cancellationToken);

        var response = new BaseResponse<Planet> { Data = planet };

        return Ok(response);
    }

    [HttpDelete]
    public async Task<ActionResult> Delete(DeletePlanetCommand command, CancellationToken cancellationToken)
    {
        await Sender.Send(command, cancellationToken);

        return Ok(new BaseResponse<Planet>());
    }
}
