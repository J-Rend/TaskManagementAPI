namespace TaskManagement.Domain.ValueObjects;

public class TaskChangeHistory
{
    public TaskChangeHistory(string fieldName, DateTime changedAt, string modifiedBy, object? oldValue, object? newValue)
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

    public object? OldValue { get; private set; }

    public object? NewValue { get; private set; }

}
