using MediatR;
using TaskManagementApp.Application.Common.Models;
using TaskManagementApp.Application.Common.Interfaces;

namespace TaskManagementApp.Application.Tasks.Commands.DeleteTask;

public class DeleteTaskCommandHandler : IRequestHandler<DeleteTaskCommand, Result>
{
    private readonly ITaskRepository _taskRepository;

    public DeleteTaskCommandHandler(ITaskRepository taskRepository)
    {
        _taskRepository = taskRepository;
    }

    public async Task<Result> Handle(DeleteTaskCommand request, CancellationToken cancellationToken)
    {
        if (request.Id <= 0)
        {
            return Result.Failure("Invalid task ID");
        }

        await _taskRepository.DeleteAsync(request.Id, cancellationToken);
        return Result.Success();
    }
}