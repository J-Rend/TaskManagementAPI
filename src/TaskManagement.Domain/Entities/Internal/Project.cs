using System.ComponentModel.DataAnnotations;
using TaskManagement.Domain.Entities.Internal.Base;

namespace TaskManagement.Domain.Entities.Internal;

public class Project : Entity
{
    public string? Title { get; private set; }

    public string? Description { get; private set; }

    public string UserId { get; private set; }

    public DateTime? RemovedAt { get; private set; }

    private Project(string? title, string? description, string userId) : base()
    {
        Title = title;
        Description = description;
        UserId = userId;
    }

    public static Project? Generate(string? title, string? description, string userId, out IEnumerable<ValidationResult> validationResults)
    {
        var project = new Project(title, description, userId);

        validationResults = project.Validate();

        if (validationResults.Any())
        {
            return null;
        }

        return project;
    }

    public void Remove()
    {
        RemovedAt = DateTime.UtcNow;
        Update();
    }

    protected override IEnumerable<ValidationResult> Validate()
    {
        var validationResults = new List<ValidationResult>();

        if (string.IsNullOrWhiteSpace(UserId))
        {
            validationResults.Add(new ValidationResult("UserId is required.", ["UserId"]));
        }

        return validationResults;
    }
}
