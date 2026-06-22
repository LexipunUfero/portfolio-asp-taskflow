using AutoMapper;
using Taskflow.Application.DTO.Project.Access;
using Taskflow.Domain.Entities;

namespace Taskflow.Application.Mappers;

public class ProjectAccessMapping: Profile
{
    public ProjectAccessMapping()
    {
        CreateMap<ProjectAccessCreateDTO, ProjectAccessEntity>()
            .ForMember(d => d.ProjectId, opt => opt.MapFrom(s => s.ProjectId))
            .ForMember(target=>target.Name, opt => opt.MapFrom(s=>s.Name))
            .ForMember(target=>target.CanManageUsers, opt => opt.MapFrom(s=>s.CanManageUsers))
            .ForMember(target=>target.CanCreateTasks, opt => opt.MapFrom(s=>s.CanCreateTasks))
            .ForMember(target=>target.CanUpdateTasks, opt => opt.MapFrom(s=>s.CanUpdateTasks))
            .ForMember(target=>target.CanRemoveTasks, opt => opt.MapFrom(s=>s.CanRemoveTasks));
        
        CreateMap<ProjectAccessUpdateDTO, ProjectAccessEntity>()
            .ForMember(d => d.Id, opt => opt.MapFrom(s => s.Id))
            .ForMember(target=>target.Name, opt => opt.MapFrom(s=>s.Name))
            .ForMember(target=>target.CanManageUsers, opt => opt.MapFrom(s=>s.CanManageUsers))
            .ForMember(target=>target.CanCreateTasks, opt => opt.MapFrom(s=>s.CanCreateTasks))
            .ForMember(target=>target.CanUpdateTasks, opt => opt.MapFrom(s=>s.CanUpdateTasks))
            .ForMember(target=>target.CanRemoveTasks, opt => opt.MapFrom(s=>s.CanRemoveTasks));

        CreateMap<ProjectAccessEntity, ProjectAccessGetDTO>()
            .ForMember(target => target.Id, opt => opt.MapFrom(s => s.Id))
            .ForMember(target => target.Name, opt => opt.MapFrom(s => s.Name))
            .ForMember(target => target.CanManageUsers, opt => opt.MapFrom(s => s.CanManageUsers))
            .ForMember(target => target.CanCreateTasks, opt => opt.MapFrom(s => s.CanCreateTasks))
            .ForMember(target => target.CanUpdateTasks, opt => opt.MapFrom(s => s.CanUpdateTasks))
            .ForMember(target => target.CanRemoveTasks, opt => opt.MapFrom(s => s.CanRemoveTasks));

        CreateMap<ProjectAccessEntity, ProjectAccessGetPreviewDTO>()
            .ForMember(target => target.Id, opt => opt.MapFrom(s => s.Id))
            .ForMember(target => target.Name, opt => opt.MapFrom(s => s.Name))
            .ForMember(target => target.IsOwner, opt => opt.MapFrom(s => s.IsOwner));

    }
}