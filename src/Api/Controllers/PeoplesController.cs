using Microsoft.AspNetCore.Mvc;
using SwApi.Api.Common.Controllers;
using SwApi.Api.Common.Responses;
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
    public async Task<ActionResult<List<People>>> GetAll(int? pageNumber, int? pageSize, CancellationToken cancellationToken)
    {
        var peoples = await Sender.Send(new GetAllPeopleQuery { PageNumber = pageNumber, PageSize = pageSize }, cancellationToken);

        var response = new BaseResponse<List<People>> { Data = peoples };

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<People?>> Get(Guid? id, CancellationToken cancellationToken)
    {
        var people = await Sender.Send(new GetPeopleQuery { Id = id }, cancellationToken);

        var response = new BaseResponse<People> { Data = people };

        return Ok(response);
    }

    [HttpPost]
    public async Task<ActionResult<People?>> Create(CreatePeopleCommand command, CancellationToken cancellationToken)
    {
        var people = await Sender.Send(command, cancellationToken);

        var response = new BaseResponse<People> { Data = people };

        return Created(response);
    }

    [HttpPut]
    public async Task<ActionResult<People?>> Update(UpdatePeopleCommand command, CancellationToken cancellationToken)
    {
        var people = await Sender.Send(command, cancellationToken);

        var response = new BaseResponse<People> { Data = people };

        return Ok(response);
    }

    [HttpDelete]
    public async Task<ActionResult> Delete(DeletePeopleCommand command, CancellationToken cancellationToken)
    {
        await Sender.Send(command, cancellationToken);

        return Ok(new BaseResponse<People>());
    }
}
