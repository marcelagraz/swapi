using MediatR;
using Microsoft.ApplicationInsights.AspNetCore.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace SwApi.Api.Common.Controllers;

[ApiController]
[Route("api/[controller]")]
public abstract class BaseController : ControllerBase
{
    private ISender? _sender;

    protected ISender Sender => _sender ??= HttpContext.RequestServices.GetRequiredService<ISender>();

    protected CreatedResult Created([ActionResultObjectValue] object? value)
    {
        return Created(HttpContext.Request.GetUri().AbsoluteUri, value);
    }
}
