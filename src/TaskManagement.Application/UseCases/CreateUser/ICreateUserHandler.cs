using TaskManagement.Application.UseCases.Base;

namespace TaskManagement.Application.UseCases.CreateUser;

public interface ICreateUserHandler : IUseCaseHandler<CreateUserInput, CreateUserOutput>
{
}
