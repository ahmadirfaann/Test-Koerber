using AutoMapper;
using TaskManagementApp.Application.DTOs;
using TaskManagementApp.Domain.Entities;

namespace TaskManagementApp.Infrastructure.Mapping;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<TaskItem, TaskDto>();
        CreateMap<CreateTaskDto, TaskItem>();
        CreateMap<UpdateTaskDto, TaskItem>();
    }
}