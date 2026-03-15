using Microsoft.AspNetCore.Mvc;
using TaskTrackerAPI.Models;
using TaskTrackerAPI.Repositories;

namespace TaskTrackerAPI.Controllers;

[ApiController]
[Route("api/tasks")]
public class TasksController : ControllerBase
{
    private readonly ITaskRepository repository;

    public TasksController(ITaskRepository repository)
    {
        this.repository = repository;
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        return Ok(repository.GetAll());
    }

    [HttpPost("bug")]
    public IActionResult CreateBug(string title, int severity)
    {
        var bug = new BugReportTask(title, severity);
        repository.Add(bug);

        return Ok(bug);
    }

    [HttpPut("{id}/complete")]
    public IActionResult Complete(Guid id)
    {
        if (!repository.Complete(id))
            return NotFound();

        return Ok();
    }
}

