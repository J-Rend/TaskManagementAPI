namespace TaskManagement.Domain.ValueObjects;

public class TaskChangeHistory
{
    public TaskChangeHistory(string fieldName, DateTime changedAt, string modifiedBy, string? oldValue, string? newValue)
    {
        FieldName = fieldName;
        ChangedAt = changedAt;
        ModifiedBy = modifiedBy;
        OldValue = oldValue;
        NewValue = newValue;
    }

    public string FieldName { get; private set; }

    public DateTime ChangedAt { get; private set; }

    public string ModifiedBy { get; private set; }

    public string? OldValue { get; private set; }

    public string? NewValue { get; private set; }

}
