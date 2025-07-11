using TaskManagement.Application.Output;

namespace TaskManagement.Application.UseCases.Base;

public interface IUseCaseHandler<TInput, TOuput>
    where TInput : class
    where TOuput : class
{
    Task<Result<TOuput>> ExecuteAsync(TInput input, CancellationToken cancellationToken);
}
