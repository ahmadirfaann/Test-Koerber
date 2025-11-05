using MediatR;
using TaskManagementApp.Application.Common.Models;

namespace TaskManagementApp.Application.Tasks.Commands.ToggleTaskCompletion;

public record ToggleTaskCompletionCommand : IRequest<Result>
{
    public int Id { get; init; }
}