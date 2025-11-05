using AutoMapper;
using MediatR;
using TaskManagementApp.Application.DTOs;
using TaskManagementApp.Application.Common.Interfaces;
using TaskManagementApp.Application.Common.Enums;

namespace TaskManagementApp.Application.Tasks.Queries.GetTasks;

public class GetTasksQueryHandler : IRequestHandler<GetTasksQuery, List<TaskDto>>
{
    private readonly ITaskRepository _taskRepository;
    private readonly IMapper _mapper;

    public GetTasksQueryHandler(ITaskRepository taskRepository, IMapper mapper)
    {
        _taskRepository = taskRepository;
        _mapper = mapper;
    }

    public async Task<List<TaskDto>> Handle(GetTasksQuery request, CancellationToken cancellationToken)
    {
        var tasks = await _taskRepository.GetAllAsync((TaskFilter)request.Filter, cancellationToken);
        return _mapper.Map<List<TaskDto>>(tasks);
    }
}