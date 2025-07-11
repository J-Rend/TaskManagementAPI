using TaskManagement.Application.Output;
using TaskManagement.Domain.Entities;
using TaskManagement.Domain.Enums;
using TaskManagement.Domain.Interfaces.Repositories;

namespace TaskManagement.Application.UseCases.CreateUser;

public class CreateUserHandler : ICreateUserHandler
{
    private readonly IUserRepository _userRepository;

    public CreateUserHandler(IUserRepository userRepository)
    {
        ArgumentNullException.ThrowIfNull(userRepository);

        _userRepository = userRepository;
    }

    public async Task<Result<CreateUserOutput>> ExecuteAsync(CreateUserInput input, CancellationToken cancellationToken)
    {
        bool isRoleSuccessfullyParsed = Enum.TryParse(input.Role, out UserRole userRole);

        if (!isRoleSuccessfullyParsed)
        {
            return Result<CreateUserOutput>.ClientError([new("Invalid User Role. Available values: Default, Manager", ["User Role"])]);
        }

        var user = User.Generate(input.Name,userRole, out var validationResults);

        if (validationResults.Any())
        {
            return Result<CreateUserOutput>.ClientError(validationResults);
        }

        await _userRepository.CreateAsync(user!);

        var output = new CreateUserOutput(user!);

        return Result<CreateUserOutput>.Success(output);
    }
}
