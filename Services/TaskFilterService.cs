using TaskTrackerAPI.Models;

namespace TaskTrackerAPI.Services;

public static class TaskFilterService
{
    public static (List<BugReportTask>, int) FilterTasks(IEnumerable<BaseTask> tasks)
    {
        var bugs = tasks
            .OfType<BugReportTask>()
            .Where(t => !t.IsCompleted && t.SeverityLevel >= 3)
            .OrderByDescending(t => t.CreatedAt)
            .ToList();

        var hours = tasks
            .OfType<FeatureRequestTask>()
            .Where(t => !t.IsCompleted)
            .Sum(t => t.EstimatedHours);

        return (bugs, hours);
    }
}

