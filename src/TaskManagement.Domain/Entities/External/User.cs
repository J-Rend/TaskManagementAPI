namespace TaskManagement.Domain.Entities.External;

public class User
{
    public User(string externalIdentifier, string role)
    {
        ExternalIdentifier = externalIdentifier;
        Role = role;
    }

    public string ExternalIdentifier { get; private set; }
    public string Role { get; private set; }
}
