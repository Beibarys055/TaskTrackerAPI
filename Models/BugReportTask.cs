namespace TaskTrackerAPI.Models;

public class BugReportTask : BaseTask
{
    public int SeverityLevel { get; set; }

    public BugReportTask(string title, int severity) : base(title)
    {
        SeverityLevel = severity;
    }
}

