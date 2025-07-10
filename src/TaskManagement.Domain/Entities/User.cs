using System.ComponentModel.DataAnnotations;
using TaskManagement.Domain.Entities.Base;
using TaskManagement.Domain.Enums;

namespace TaskManagement.Domain.Entities;

public class User : Entity
{
    private User(string userName, UserRole userRole) : base()
    {
        Name = userName;
        Role = userRole;
    }

    public static User? Generate(string userName, UserRole userRole, out IEnumerable<ValidationResult> validationResults)
    {
        var user = new User(userName,userRole);

        validationResults = user.Validate();

        return !validationResults.Any() ? user : null;
    }

    protected override IEnumerable<ValidationResult> Validate()
    {
        var validationResults = new List<ValidationResult>();

        if (string.IsNullOrWhiteSpace(Name))
        {
            validationResults.Add(new("User name not given", ["User.UserName"]));
        }

        return validationResults;
    }

    public string Name { get; private set; }
    public UserRole Role { get; private set; }
}
