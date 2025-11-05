using MediatR;
using TaskManagementApp.Application.DTOs;
using TaskManagementApp.Application.Common.Enums;

namespace TaskManagementApp.Application.Tasks.Queries.GetTasks;

public record GetTasksQuery : IRequest<List<TaskDto>>
{
    public TaskFilter Filter { get; init; } = TaskFilter.All;
}