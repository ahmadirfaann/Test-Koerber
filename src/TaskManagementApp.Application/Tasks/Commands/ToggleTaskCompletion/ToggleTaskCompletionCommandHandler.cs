using MediatR;
using TaskManagementApp.Application.Common.Models;
using TaskManagementApp.Application.Common.Interfaces;

namespace TaskManagementApp.Application.Tasks.Commands.ToggleTaskCompletion;

public class ToggleTaskCompletionCommandHandler : IRequestHandler<ToggleTaskCompletionCommand, Result>
{
    private readonly ITaskRepository _taskRepository;

    public ToggleTaskCompletionCommandHandler(ITaskRepository taskRepository)
    {
        _taskRepository = taskRepository;
    }

    public async Task<Result> Handle(ToggleTaskCompletionCommand request, CancellationToken cancellationToken)
    {
        if (request.Id <= 0)
        {
            return Result.Failure("Invalid task ID");
        }

        var task = await _taskRepository.GetByIdAsync(request.Id, cancellationToken);
        if (task == null)
        {
            return Result.Failure("Task not found");
        }

        if (task.IsCompleted)
        {
            task.MarkAsPending();
        }
        else
        {
            task.MarkAsCompleted();
        }

        await _taskRepository.UpdateAsync(task, cancellationToken);
        return Result.Success();
    }
}