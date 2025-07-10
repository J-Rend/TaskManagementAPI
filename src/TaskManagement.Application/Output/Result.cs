using System.ComponentModel.DataAnnotations;

namespace TaskManagement.Application.Output;

public class Result<T> where T : class
{
    public T? Data { get; private set; }
    public IEnumerable<ValidationResult> Errors { get; private set; }
    public ResultStatus Status { get; private set; }
    public string ErrorMessage { get; private set; }

    private Result(T? data, IEnumerable<ValidationResult>? errors, ResultStatus resultStatus, string? errorMessage)
    {
        Data = data;
        Errors = errors ?? new List<ValidationResult>();
        Status = resultStatus;
        ErrorMessage = errorMessage ?? string.Empty;
    }

    public static Result<T> Success(T data)
    {
        return new Result<T>(data, Enumerable.Empty<ValidationResult>(), ResultStatus.Success,null);
    }

    public static Result<T> ClientError(IEnumerable<ValidationResult> errors)
    {
        return new Result<T>(null, errors, ResultStatus.ClientError, null);
    }

    public static Result<T> ServerError(string errorMessage)
    {
        return new Result<T>(null, null, ResultStatus.ServerError, errorMessage);
    }

    public static Result<T> NotFound()
    {
        return new Result<T>(null, Enumerable.Empty<ValidationResult>(), ResultStatus.NotFound, null);
    }
}
