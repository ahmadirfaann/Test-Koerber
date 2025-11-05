using MediatR;
using TaskManagementApp.Application.Common.Models;
using TaskManagementApp.Application.DTOs;

namespace TaskManagementApp.Application.Tasks.Commands.CreateTask;

public record CreateTaskCommand : IRequest<Result<int>>
{
    public string Title { get; init; } = string.Empty;
    public string Description { get; init; } = string.Empty;
}