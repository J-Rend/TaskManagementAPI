using MongoDB.Bson;
using System.ComponentModel.DataAnnotations;
using TaskManagement.Domain.Entities.Base;

namespace TaskManagement.Domain.Entities;

public class Project : Entity
{
    public string Title { get; private set; }
    public string? Description { get; private set; }
    public DateTime? RemovedAt { get; private set; }
    public ObjectId ResponsibleUserId { get; private set; }


    protected override IEnumerable<ValidationResult> Validate()
    {
        throw new NotImplementedException();
    }
}
