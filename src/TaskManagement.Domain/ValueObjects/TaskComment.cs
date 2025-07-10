using MongoDB.Bson;

namespace TaskManagement.Domain.ValueObjects;

public class TaskComment
{
    public ObjectId UserId { get; private set; }
    public string Comment { get; private set; }

    public TaskComment(ObjectId userId, string comment)
    {
        UserId = userId;
        Comment = comment;
    }
}
