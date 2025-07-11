using System.ComponentModel.DataAnnotations;

namespace TaskManagement.Application.Output;

public class Result<T> where T : class
{
    public T? Data { get; private set; }
    public IEnumerable<ValidationResult> Errors { get; private set; }
    public ResultStatus Status { get; private set; }
    public string ServerErrorMessage { get; private set; }
    public string? ResourcePath { get; private set; }

    private Result(T? data, IEnumerable<ValidationResult>? errors, ResultStatus resultStatus, string? errorMessage, string? resourcePath)
    {
        Data = data;
        Errors = errors ?? new List<ValidationResult>();
        Status = resultStatus;
        ServerErrorMessage = errorMessage ?? string.Empty;
        ResourcePath = resourcePath;
    }

    public static Result<T> Success(T data)
    {
        return new Result<T>(data, Enumerable.Empty<ValidationResult>(), ResultStatus.Success,null, null);
    }

    public static Result<T> Created(T data, string resourcePath)
    {
        return new Result<T>(data, Enumerable.Empty<ValidationResult>(), ResultStatus.Created, null, resourcePath);
    }

    public static Result<T> NoContent()
    {
        return new Result<T>(null, Enumerable.Empty<ValidationResult>(), ResultStatus.NoContent, null, null);
    }

    public static Result<T> ClientError(IEnumerable<ValidationResult> errors)
    {
        return new Result<T>(null, errors, ResultStatus.ClientError, null, null);
    }

    public static Result<T> ServerError(string errorMessage)
    {
        return new Result<T>(null, null, ResultStatus.ServerError, errorMessage, null);
    }

    public static Result<T> NotFound()
    {
        return new Result<T>(null, Enumerable.Empty<ValidationResult>(), ResultStatus.NotFound, null, null);
    }
}
