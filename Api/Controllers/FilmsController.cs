using Microsoft.AspNetCore.Mvc;
using SwApi.Api.Common;
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
    public async Task<ActionResult<List<Film>>> GetAll(int? pageNumber, int? pageSize, CancellationToken cancellationToken) =>
        await Sender.Send(new GetAllFilmQuery { PageNumber = pageNumber, PageSize = pageSize }, cancellationToken);

    [HttpGet("{id}")]
    public async Task<ActionResult<Film?>> Get(Guid? id, CancellationToken cancellationToken) =>
        await Sender.Send(new GetFilmQuery { Id = id }, cancellationToken);

    [HttpPost]
    public async Task<ActionResult<Film?>> Create(CreateFilmCommand command, CancellationToken cancellationToken) =>
        await Sender.Send(command, cancellationToken);

    [HttpPut("{id}")]
    public async Task<ActionResult<Film?>> Update(UpdateFilmCommand command, CancellationToken cancellationToken) =>
        await Sender.Send(command, cancellationToken);

    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(DeleteFilmCommand command, CancellationToken cancellationToken)
    {
        await Sender.Send(command, cancellationToken);

        return NoContent();
    }
}
