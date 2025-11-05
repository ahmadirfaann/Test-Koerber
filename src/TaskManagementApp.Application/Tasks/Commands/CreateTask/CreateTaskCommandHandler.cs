using MediatR;
using TaskManagementApp.Application.Common.Models;
using TaskManagementApp.Application.Common.Interfaces;
using TaskManagementApp.Domain.Entities;

namespace TaskManagementApp.Application.Tasks.Commands.CreateTask;

public class CreateTaskCommandHandler : IRequestHandler<CreateTaskCommand, Result<int>>
{
    private readonly ITaskRepository _taskRepository;

    public CreateTaskCommandHandler(ITaskRepository taskRepository)
    {
        _taskRepository = taskRepository;
    }

    public async Task<Result<int>> Handle(CreateTaskCommand request, CancellationToken cancellationToken)
    {
        if (string.IsNullOrWhiteSpace(request.Title))
        {
            return Result<int>.Failure("Task title is required");
        }

        var task = new TaskItem
        {
            Title = request.Title.Trim(),
            Description = request.Description?.Trim() ?? string.Empty
        };

        var createdTask = await _taskRepository.CreateAsync(task, cancellationToken);
        return Result<int>.Success(createdTask.Id);
    }
}