using System.ComponentModel.DataAnnotations;

namespace TaskManagement.Application.Output;

public class Result<T> where T : class
{
    public T? Data { get; private set; }
    public IEnumerable<ValidationResult> Errors { get; private set; }
    public ResultStatus ResultStatus { get; private set; }

    private Result(T? data, IEnumerable<ValidationResult> errors, ResultStatus resultStatus)
    {
        Data = data;
        Errors = errors ?? new List<ValidationResult>();
        ResultStatus = resultStatus;
    }

    public static Result<T> Success(T data)
    {
        return new Result<T>(data, Enumerable.Empty<ValidationResult>(), ResultStatus.Success);
    }

    public static Result<T> ClientError(IEnumerable<ValidationResult> errors)
    {
        return new Result<T>(null, errors, ResultStatus.ClientError);
    }

    public static Result<T> ServerError(IEnumerable<ValidationResult> errors)
    {
        return new Result<T>(null, errors, ResultStatus.ServerError);
    }

    public static Result<T> NotFound()
    {
        return new Result<T>(null, Enumerable.Empty<ValidationResult>(), ResultStatus.NotFound);
    }
}
