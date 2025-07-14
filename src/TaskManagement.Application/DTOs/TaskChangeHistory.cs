namespace TaskManagement.Application.DTO;

public class TaskChangeHistory
{
    public TaskChangeHistory(Domain.ValueObjects.TaskChangeHistory taskChangeHistory)
    {
        FieldName = taskChangeHistory.FieldName;
        OldValue = taskChangeHistory.OldValue;
        NewValue = taskChangeHistory.NewValue;
        ChangedAt = taskChangeHistory.ChangedAt;
        ModifiedBy = taskChangeHistory.ModifiedBy;
    }

    public string FieldName { get; private set; }

    public string? OldValue { get; private set; }

    public string? NewValue { get; private set; }

    public DateTime ChangedAt { get; private set; }

    public string ModifiedBy { get; private set; }
}
