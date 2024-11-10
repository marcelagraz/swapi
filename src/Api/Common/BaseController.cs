﻿using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace SwApi.Api.Common;

[ApiController]
[Route("[controller]")]
public abstract class BaseController : ControllerBase
{
    private ISender? _sender;

    protected ISender Sender => _sender ??= HttpContext.RequestServices.GetRequiredService<ISender>();
}
