namespace TaskManagement.Application.Output;

public enum ResultStatus
{
    Success = 1,
    Created = 2,
    NoContent = 3,
    ClientError = 4,
    ServerError = 5,
    NotFound = 6
}
