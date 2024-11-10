using Microsoft.AspNetCore.Mvc;

namespace SwApi.Api.Common.Responses;

public class BaseResponse<TResponse> : ProblemDetails
{
    public TResponse? Data { get; set; }

    public List<ValidationError> ValidationErrors { get; set; } = [];
}
