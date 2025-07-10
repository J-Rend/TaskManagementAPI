using MongoDB.Bson;

namespace TaskManagement.Domain.ValueObjects;

public class TaskChangeHistoryItem
{
    public string FieldName { get; private set; }
    public string OldValue { get; private set; }
    public string NewValue { get; private set; }
    public DateTime ChangedAt { get; private set; }
    public ObjectId ModifiedBy { get; private set; }

}
