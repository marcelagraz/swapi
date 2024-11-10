using Microsoft.AspNetCore.Mvc;
using SwApi.Api.Common.Controllers;
using SwApi.Api.Common.Responses;
using SwApi.Application.Films.Commands.CreateFilm;
using SwApi.Application.Films.Commands.DeleteFilm;
using SwApi.Application.Films.Commands.UpdateFilm;
using SwApi.Application.Films.Queries.GetAllFilm;
using SwApi.Application.Films.Queries.GetFilm;
using SwApi.Domain.Entities;

namespace SwApi.Api.Controllers;

public class FilmsController : BaseController
{
    [HttpGet]
    public async Task<ActionResult<List<Film>>> GetAll(int? pageNumber, int? pageSize, CancellationToken cancellationToken)
    {
        var films = await Sender.Send(new GetAllFilmQuery { PageNumber = pageNumber, PageSize = pageSize }, cancellationToken);

        var response = new BaseResponse<List<Film>> { Data = films };

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Film?>> Get(Guid? id, CancellationToken cancellationToken)
    {
        var film = await Sender.Send(new GetFilmQuery { Id = id }, cancellationToken);

        var response = new BaseResponse<Film> { Data = film };

        return Ok(response);
    }

    [HttpPost]
    public async Task<ActionResult<Film?>> Create(CreateFilmCommand command, CancellationToken cancellationToken)
    {
        var film = await Sender.Send(command, cancellationToken);

        var response = new BaseResponse<Film> { Data = film };

        return Created(response);
    }

    [HttpPut]
    public async Task<ActionResult<Film?>> Update(UpdateFilmCommand command, CancellationToken cancellationToken)
    {
        var film = await Sender.Send(command, cancellationToken);

        var response = new BaseResponse<Film> { Data = film };

        return Ok(response);
    }

    [HttpDelete]
    public async Task<ActionResult> Delete(DeleteFilmCommand command, CancellationToken cancellationToken)
    {
        await Sender.Send(command, cancellationToken);

        return Ok(new BaseResponse<People>());
    }
}
