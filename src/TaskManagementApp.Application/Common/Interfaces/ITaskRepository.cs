using TaskManagementApp.Application.Common.Enums;
using TaskManagementApp.Domain.Entities;

namespace TaskManagementApp.Application.Common.Interfaces;

public interface ITaskRepository
{
    Task<List<TaskItem>> GetAllAsync(TaskFilter filter, CancellationToken cancellationToken = default);
    Task<TaskItem?> GetByIdAsync(int id, CancellationToken cancellationToken = default);
    Task<TaskItem> CreateAsync(TaskItem task, CancellationToken cancellationToken = default);
    Task UpdateAsync(TaskItem task, CancellationToken cancellationToken = default);
    Task DeleteAsync(int id, CancellationToken cancellationToken = default);
}