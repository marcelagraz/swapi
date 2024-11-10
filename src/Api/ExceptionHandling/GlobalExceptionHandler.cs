using Ardalis.GuardClauses;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SwApi.Api.Common.Responses;
using SwApi.Application.Common.Exceptions;

namespace SwApi.Api.ExceptionHandling;

public class GlobalExceptionHandler : IExceptionHandler
{
    private readonly IDictionary<Type, Func<HttpContext, Exception, CancellationToken, ValueTask<bool>>> _exceptionHandlers;
    private readonly ILogger<GlobalExceptionHandler> _logger;

    public GlobalExceptionHandler(ILogger<GlobalExceptionHandler> logger)
    {
        _exceptionHandlers = new Dictionary<Type, Func<HttpContext, Exception, CancellationToken, ValueTask<bool>>>
        {
            { typeof(ValidationException), HandleValidationException },
            { typeof(NotFoundException), HandleNotFoundException },
            { typeof(DbUpdateConcurrencyException), HandleDbUpdateConcurrencyException }
        };

        _logger = logger;
    }

    public async ValueTask<bool> TryHandleAsync(
        HttpContext httpContext,
        Exception exception,
        CancellationToken cancellationToken)
    {
        Type type = exception.GetType();

        if (_exceptionHandlers.TryGetValue(type, out Func<HttpContext, Exception, CancellationToken, ValueTask<bool>>? func))
        {
            return await func.Invoke(httpContext, exception, cancellationToken);
        }

        return await HandleUnknownException(httpContext, exception, cancellationToken);
    }

    private async ValueTask<bool> HandleValidationException(
        HttpContext context,
        Exception exception,
        CancellationToken cancellationToken)
    {
        context.Response.StatusCode = StatusCodes.Status400BadRequest;

        var validationException = (ValidationException)exception;

        List<ValidationError> ValidationErrors = [];

        foreach (var field in validationException.Errors.Keys)
        {
            ValidationErrors.Add(new ValidationError
            {
                Field = field,
                Messages = [.. validationException.Errors[field]]
            });
        }

        await context.Response.WriteAsJsonAsync(new BaseResponse<object>
        {
            Status = StatusCodes.Status400BadRequest,
            Type = "https://tools.ietf.org/html/rfc7231#section-6.5.1",
            Title = "The server cannot will not process the request due to something that is perceived to be a client error.",
            Detail = exception.Message,
            ValidationErrors = ValidationErrors
        }, cancellationToken);

        return true;
    }

    private async ValueTask<bool> HandleNotFoundException(
        HttpContext context,
        Exception exception,
        CancellationToken cancellationToken)
    {
        context.Response.StatusCode = StatusCodes.Status404NotFound;

        await context.Response.WriteAsJsonAsync(new BaseResponse<object>()
        {
            Status = StatusCodes.Status404NotFound,
            Type = "https://tools.ietf.org/html/rfc7231#section-6.5.4",
            Title = "The specified resource was not found.",
            Detail = exception.Message
        }, cancellationToken);

        return true;
    }

    private async ValueTask<bool> HandleDbUpdateConcurrencyException(
        HttpContext context,
        Exception exception,
        CancellationToken cancellationToken)
    {
        context.Response.StatusCode = StatusCodes.Status409Conflict;

        await context.Response.WriteAsJsonAsync(new BaseResponse<object>
        {
            Status = StatusCodes.Status409Conflict,
            Type = "https://tools.ietf.org/html/rfc7231#section-6.5.8",
            Title = "The request could not be completed due to a conflict with the current state of the target resource.",
            Detail = exception.Message
        }, cancellationToken);

        return true;
    }

    private async ValueTask<bool> HandleUnknownException(
        HttpContext context,
        Exception exception,
        CancellationToken cancellationToken)
    {
        context.Response.StatusCode = StatusCodes.Status500InternalServerError;

        await context.Response.WriteAsJsonAsync(new BaseResponse<object>
        {
            Status = StatusCodes.Status500InternalServerError,
            Type = "https://tools.ietf.org/html/rfc7231#section-6.6.1",
            Title = "The server encountered an unexpected condition that prevented it from fulfilling the request.",
            Detail = exception.Message
        }, cancellationToken);

        return true;
    }
}
