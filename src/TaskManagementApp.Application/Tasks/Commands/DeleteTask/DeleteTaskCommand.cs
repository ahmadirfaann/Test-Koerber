using MediatR;
using TaskManagementApp.Application.Common.Models;

namespace TaskManagementApp.Application.Tasks.Commands.DeleteTask;

public record DeleteTaskCommand : IRequest<Result>
{
    public int Id { get; init; }
}