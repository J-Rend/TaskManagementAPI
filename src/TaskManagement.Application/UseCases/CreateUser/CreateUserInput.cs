namespace TaskManagement.Application.UseCases.CreateUser;

public class CreateUserInput
{
    public string Name { get; private set; }
    public string Role { get; private set; }

    public CreateUserInput(string name, string role)
    {
        Name = name;
        Role = role;
    }

}
