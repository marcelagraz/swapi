using Microsoft.AspNetCore.Mvc;
using SwApi.Api.Common;
using SwApi.Application.Peoples.Commands.CreatePeople;
using SwApi.Application.Peoples.Commands.DeletePeople;
using SwApi.Application.Peoples.Commands.UpdatePeople;
using SwApi.Application.Peoples.Queries.GetAllPeople;
using SwApi.Application.Peoples.Queries.GetPeople;
using SwApi.Domain.Entities;

namespace SwApi.Api.Controllers;

public class PeoplesController : BaseController
{
    [HttpGet]
    public async Task<ActionResult<List<People>>> GetAll(int? pageNumber, int? pageSize, CancellationToken cancellationToken) =>
        await Sender.Send(new GetAllPeopleQuery { PageNumber = pageNumber, PageSize = pageSize }, cancellationToken);

    [HttpGet("{id}")]
    public async Task<ActionResult<People?>> Get(Guid? id, CancellationToken cancellationToken) =>
        await Sender.Send(new GetPeopleQuery { Id = id }, cancellationToken);

    [HttpPost]
    public async Task<ActionResult<People?>> Create(CreatePeopleCommand command, CancellationToken cancellationToken) =>
        await Sender.Send(command, cancellationToken);

    [HttpPut("{id}")]
    public async Task<ActionResult<People?>> Update(UpdatePeopleCommand command, CancellationToken cancellationToken) =>
        await Sender.Send(command, cancellationToken);

    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(DeletePeopleCommand command, CancellationToken cancellationToken)
    {
        await Sender.Send(command, cancellationToken);

        return Ok();
    }
}
