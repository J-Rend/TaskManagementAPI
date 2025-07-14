using System.Diagnostics.CodeAnalysis;

namespace TaskManagement.Infrastructure.MongoDB;

[ExcludeFromCodeCoverage]
public class MongoDbSettings
{
    public string ConnectionString { get; set; }
    public string DatabaseName { get; set; }
}
