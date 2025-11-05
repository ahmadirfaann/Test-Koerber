using MediatR;
using Microsoft.AspNetCore.Mvc;
using TaskManagementApp.Application.Tasks.Commands.CreateTask;
using TaskManagementApp.Application.Tasks.Commands.DeleteTask;
using TaskManagementApp.Application.Tasks.Commands.ToggleTaskCompletion;
using TaskManagementApp.Application.Tasks.Queries.GetTasks;
using TaskManagementApp.Application.Common.Enums;

namespace TaskManagementApp.Web.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TasksController : ControllerBase
{
    private readonly IMediator _mediator;

    public TasksController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> GetTasks([FromQuery] int filter = 0, CancellationToken cancellationToken = default)
    {
        var tasks = await _mediator.Send(new GetTasksQuery { Filter = (TaskFilter)filter }, cancellationToken);
        return Ok(tasks);
    }

    [HttpPost]
    public async Task<IActionResult> CreateTask([FromBody] CreateTaskCommand command, CancellationToken cancellationToken = default)
    {
        var result = await _mediator.Send(command, cancellationToken);

        if (result.IsSuccess)
            return Ok(new { success = true, taskId = result.Value });

        return BadRequest(new { success = false, error = result.Error });
    }

    [HttpPut("{id}/toggle")]
    public async Task<IActionResult> ToggleTask(int id, CancellationToken cancellationToken = default)
    {
        var result = await _mediator.Send(new ToggleTaskCompletionCommand { Id = id }, cancellationToken);

        if (result.IsSuccess)
            return Ok(new { success = true });

        return BadRequest(new { success = false, error = result.Error });
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteTask(int id, CancellationToken cancellationToken = default)
    {
        var result = await _mediator.Send(new DeleteTaskCommand { Id = id }, cancellationToken);

        if (result.IsSuccess)
            return Ok(new { success = true });

        return BadRequest(new { success = false, error = result.Error });
    }
}
