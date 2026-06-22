using AutoMapper;
using Taskflow.Application.DTO.Task;
using Taskflow.Domain.Entities;

namespace Taskflow.Application.Mappers;

public class TaskMapping: Profile
{
    public TaskMapping()
    {
        CreateMap<TaskCreateDTO, TaskEntity>()
            .ForMember(destination => destination.Name, source => source.MapFrom(src => src.Name))
            .ForMember(destination => destination.Index, option => option.MapFrom(src => src.Index))
            .ForMember(destination => destination.DashboardId, source => source.MapFrom(src => src.DashboardId));
        
        CreateMap<TaskUpdateDTO, TaskEntity>()
            .ForMember(destination => destination.Id, source => source.MapFrom(src => src.Id))
            .ForMember(destination => destination.Name, source => source.MapFrom(src => src.Name))
            .ForMember(destination => destination.Description, source => source.MapFrom(src => src.Description))
            .ForMember(destination => destination.Index, option => option.MapFrom(src => src.Index))
            .ForMember(destination => destination.DashboardId, source => source.MapFrom(src => src.DashboardId))
            .ForMember(destination => destination.EndDate, source => source.MapFrom(src => src.DateEnd))
            .ForMember(destination => destination.StartDate, source => source.MapFrom(src => src.DateStart))
            .ForMember(destination => destination.RowVersion, option => option.MapFrom(source => source.RowVersion));

        CreateMap<TaskEntity,TaskGetDTO>()
            .ForMember(destination => destination.Id, source => source.MapFrom(src => src.Id))
            .ForMember(destination => destination.Name, source => source.MapFrom(src => src.Name))
            .ForMember(destination => destination.Description, source => source.MapFrom(src => src.Description))
            .ForMember(destination => destination.Index, source => source.MapFrom(src => src.Index))
            .ForMember(destination => destination.DashboardId, source => source.MapFrom(src => src.DashboardId))
            .ForMember(destination => destination.DateEnd, source => source.MapFrom(src => src.EndDate))
            .ForMember(destination => destination.DateStart, source => source.MapFrom(src => src.StartDate))
            .ForMember(destination => destination.Labels, source => source.MapFrom(src => src.Markdowns))
            .ForMember(destination => destination.RowVersion, source => source.MapFrom(src => src.RowVersion));
    }
}