using Task = TaskManagement.Domain.Entities.Internal.Task;

namespace TaskManagement.Tests.Arrangements
{
    public static class TaskArrangements
    {
        public static Task ValidPendingTask => Task.Generate(
            "Test Task",
            "This is a test task.",
            DateTime.UtcNow.AddDays(7),
            "Pending",
            "High",
            Guid.NewGuid().ToString(),
            out var validationResults
        )!;

        public static Task ValidFinishedTask => Task.Generate(
            "Test Task",
            "This is a test task.",
            DateTime.UtcNow.AddDays(7),
            "Finished",
            "High",
            Guid.NewGuid().ToString(),
            out var validationResults
        )!;

        public static Task ValidInProgressTask => Task.Generate(
            "Test Task",
            "This is a test task.",
            DateTime.UtcNow.AddDays(7),
            "InProgress",
            "High",
            Guid.NewGuid().ToString(),
            out var validationResults
        )!;
    }
}
