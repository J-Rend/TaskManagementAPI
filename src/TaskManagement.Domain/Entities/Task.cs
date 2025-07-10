using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.ComponentModel.DataAnnotations;
using TaskManagement.Domain.Entities.Base;
using TaskManagement.Domain.ValueObjects;

namespace TaskManagement.Domain.Entities;

public class Task : Entity
{
    public string Title { get; private set; }

    public string Description { get; private set; }

    public DateTime DueDate { get; private set; }

    public Enums.TaskStatus Status { get; private set; }

    public Enums.TaskPriority Priority { get; private set; }

    [BsonRepresentation(BsonType.ObjectId)]
    public string ProjectId { get; private set; }

    public IEnumerable<TaskComment> Comments { get; private set; }

    public IEnumerable<TaskChangeHistory> ChangeHistory { get; private set; }

    protected override IEnumerable<ValidationResult> Validate()
    {
        throw new NotImplementedException();
    }
}
