using TaskTrackerAPI.Models;

namespace TaskTrackerAPI.Repositories;

public class InMemoryTaskRepository : ITaskRepository
{
    private readonly List<BaseTask> tasks = new();

    public IEnumerable<BaseTask> GetAll() => tasks;

    public BaseTask? GetById(Guid id)
    {
        return tasks.FirstOrDefault(t => t.Id == id);
    }

    public void Add(BaseTask task)
    {
        tasks.Add(task);
    }

    public bool Complete(Guid id)
    {
        var task = GetById(id);
        if (task == null) return false;

        task.CompleteTask();
        return true;
    }
}

