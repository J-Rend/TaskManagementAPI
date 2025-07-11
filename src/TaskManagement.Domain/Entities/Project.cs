using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.ComponentModel.DataAnnotations;
using TaskManagement.Domain.Entities.Base;

namespace TaskManagement.Domain.Entities;

public class Project : Entity
{
    public string Title { get; private set; }

    public string? Description { get; private set; }

    public DateTime? RemovedAt { get; private set; }

    [BsonRepresentation(BsonType.ObjectId)]
    public string ResponsibleUserId { get; private set; }

    private Project(string title, string? description, DateTime? removedAt, string responsibleUserId)
    {
        Title = title;
        Description = description;
        RemovedAt = removedAt;
        ResponsibleUserId = responsibleUserId;
    }

    public static Project? Generate(string title, string? description, DateTime? removedAt, string responsibleUserId, out IEnumerable<ValidationResult> validationResults)
    {
        var project = new Project(title, description, removedAt, responsibleUserId);

        validationResults = project.Validate();

        if (validationResults.Any())
        {
            return null;
        }

        return project;
    }

    protected override IEnumerable<ValidationResult> Validate()
    {
        throw new NotImplementedException();
    }
}
