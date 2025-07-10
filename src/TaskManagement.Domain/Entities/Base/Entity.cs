using MongoDB.Bson;
using System.ComponentModel.DataAnnotations;

namespace TaskManagement.Domain.Entities.Base;

public abstract class Entity
{
    public ObjectId Id { get; private set; } 

    public DateTime CreatedAt { get; private set; }
    public DateTime? UpdatedAt { get; private set; }
    public DateTime? DeletedAt { get; private set; }

    protected abstract IEnumerable<ValidationResult> Validate();

    protected Entity()
    {
        Id = ObjectId.GenerateNewId();
        CreatedAt = DateTime.UtcNow;
    }

    public void Update()
    {
        UpdatedAt = DateTime.UtcNow;
    }

    public void Delete()
    {
        DeletedAt = DateTime.UtcNow;
    }
}
