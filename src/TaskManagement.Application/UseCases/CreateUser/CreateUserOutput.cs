using TaskManagement.Domain.Entities;

namespace TaskManagement.Application.UseCases.CreateUser;

public class CreateUserOutput
{
    public string Id { get; private set; }
    public string Name { get; private set; }
    public string Role { get; private set; }

    public CreateUserOutput(User user)
    {
        Id = user.Id;
        Name = user.Name;
        Role = user.Role.ToString();
    }
}
