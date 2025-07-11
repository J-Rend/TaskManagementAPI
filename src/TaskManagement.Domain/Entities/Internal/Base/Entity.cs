using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.ComponentModel.DataAnnotations;

namespace TaskManagement.Domain.Entities.Internal.Base;

public abstract class Entity
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string Id { get; private set; }

    public DateTime CreatedAt { get; private set; }
    public DateTime? UpdatedAt { get; private set; }

    protected abstract IEnumerable<ValidationResult> Validate();

    protected Entity()
    {
        CreatedAt = DateTime.UtcNow;
    }

    protected void Update()
    {
        UpdatedAt = DateTime.UtcNow;
    }
}
