using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace TaskManagement.Domain.ValueObjects;

public class TaskChangeHistoryItem
{
    public string FieldName { get; private set; }

    public string OldValue { get; private set; }

    public string NewValue { get; private set; }

    public DateTime ChangedAt { get; private set; }

    [BsonRepresentation(BsonType.ObjectId)]
    public string ModifiedBy { get; private set; }

}
