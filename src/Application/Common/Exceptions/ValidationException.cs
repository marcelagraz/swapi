using FluentValidation.Results;

namespace SwApi.Application.Common.Exceptions;

public class ValidationException : Exception
{
    public ValidationException()
        : base("One or more validation failures have occurred.")
    {
        Errors = new Dictionary<string, string[]>();
    }

    public ValidationException(IEnumerable<ValidationFailure> failures) : this()
    {
        Errors = failures
            .GroupBy(e => e.PropertyName, e => e.ErrorMessage)
            .ToDictionary(failureGroup => failureGroup.Key, failureGroup => failureGroup.ToArray());
    }

    public ValidationException(string property, string error) : this()
    {
        Errors = new Dictionary<string, string[]>
        {
            { property, [error] }
        };
    }

    public ValidationException(string property, string error, string message, Exception exception) : base(message, exception)
    {
        Errors = new Dictionary<string, string[]>
        {
            { property, [error] }
        };
    }

    public ValidationException(string property, IEnumerable<string> errors) : this()
    {
        Errors = new Dictionary<string, string[]>
        {
            { property, errors.ToArray() }
        };
    }

    public IDictionary<string, string[]> Errors { get; }
}
