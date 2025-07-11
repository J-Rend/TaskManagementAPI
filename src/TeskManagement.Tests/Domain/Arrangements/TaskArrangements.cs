using Task = TaskManagement.Domain.Entities.Internal.Task;

namespace TaskManagement.Tests.Domain.Arrangements
{
    public static class TaskArrangements
    {
        public static Task ValidTask => Task.Generate(
            "Test Task",
            "This is a test task.",
            DateTime.UtcNow.AddDays(7),
            "Pending",
            "High",
            Guid.NewGuid().ToString(),
            out var validationResults
        )!;
    }
}
