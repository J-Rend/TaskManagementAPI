using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.ComponentModel.DataAnnotations;
using System.Text.Json;
using TaskManagement.Domain.Entities.Internal.Base;
using TaskManagement.Domain.Enums;
using TaskManagement.Domain.ValueObjects;

namespace TaskManagement.Domain.Entities.Internal;

public class Task : Entity
{
    public string Title { get; private set; }

    public string Description { get; private set; }

    public DateTime DueDate { get; private set; }

    public Enums.TaskStatus Status { get; private set; }

    public TaskPriority Priority { get; private set; }

    [BsonRepresentation(BsonType.ObjectId)]
    public string? ProjectId { get; private set; }

    public IEnumerable<TaskComment> Comments { get; private set; }

    public IEnumerable<TaskChangeHistory> ChangeHistory { get; private set; }

    private Task(string title, string description, DateTime dueDate, Enums.TaskStatus status, TaskPriority priority, string? projectId)
    {
        Title = title;
        Description = description;
        DueDate = dueDate;
        Status = status;
        Priority = priority;
        ProjectId = projectId;
        Comments = [];
        ChangeHistory = [];
    }

    public static Task? Generate(string title, string description, DateTime dueDate, string status, string priority, string? projectId, out IEnumerable<ValidationResult> validationResults)
    {
        var successfullyParsedStatus = Enum.TryParse<Enums.TaskStatus>(status, true, out var taskStatus);
        var successfullyParsedPriority = Enum.TryParse<TaskPriority>(priority, true, out var taskPriority);

        if (!successfullyParsedStatus)
        {
            taskStatus = Enums.TaskStatus.None;
        }
        if(!successfullyParsedPriority)
        {
            taskPriority = TaskPriority.None;
        }

        var task = new Task(title,description,dueDate,taskStatus,taskPriority,projectId);

        validationResults = task.Validate();

        if (validationResults.Any())
        {
            return null;
        }

        return task;
    }

    public void RemoveFromProject(string userId)
    {
        AddChangeHistory(new("ProjectId", DateTime.Now, userId, ProjectId, null));

        ProjectId = null;

        Update();
    }

    public void AppendComment(TaskComment comment)
    {
        var oldValue = Comments.ToList();
        Comments = Comments.Append(comment);

        var serializedOldValue = JsonSerializer.Serialize(oldValue);
        var serializedNewValue = JsonSerializer.Serialize(Comments);

        AddChangeHistory(new("Comments", DateTime.Now, comment.UserId, serializedOldValue, serializedNewValue));
        Update();
    }

    private void AddChangeHistory(TaskChangeHistory taskChangeHistory)
    {
        ChangeHistory = ChangeHistory.Append(taskChangeHistory);
    }

    public void UpdateStatus(string status, string userId, out IEnumerable<ValidationResult> validationResults)
    {
        var successfullyParsedStatus = Enum.TryParse<Enums.TaskStatus>(status, true, out var taskStatus);

        if (!successfullyParsedStatus)
        {
            taskStatus = Enums.TaskStatus.None;
        }

        AddChangeHistory(new("Status", DateTime.Now, userId, Status.ToString(), taskStatus.ToString()));

        Status = taskStatus;

        validationResults = Validate();
        Update();
    }

    protected override IEnumerable<ValidationResult> Validate()
    {
        var validationResults = new List<ValidationResult>();

        if (string.IsNullOrWhiteSpace(Title))
        {
            validationResults.Add(new ValidationResult("Title is required.", ["Title"]));
        }

        if (string.IsNullOrWhiteSpace(Description))
        {
            validationResults.Add(new ValidationResult("Description is required.", ["Description"]));
        }

        if (DueDate < DateTime.UtcNow)
        {
            validationResults.Add(new ValidationResult("Due date cannot be in the past.", ["DueDate"]));
        }

        if (Status == Enums.TaskStatus.None)
        {
            validationResults.Add(new ValidationResult("Invalid status.", ["Status"]));
        }

        if (Priority == Enums.TaskPriority.None)
        {
            validationResults.Add(new ValidationResult("Invalid priority.", ["Priority"]));
        }

        return validationResults;
    }
}
