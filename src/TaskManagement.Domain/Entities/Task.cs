using MongoDB.Bson;
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
    public ObjectId ProjectId { get; private set; }
    public IEnumerable<TaskComment> Comments { get; private set; }
    public IEnumerable<TaskChangeHistoryItem> ChangeHistory { get; private set; }

    protected override IEnumerable<ValidationResult> Validate()
    {
        throw new NotImplementedException();
    }
}
