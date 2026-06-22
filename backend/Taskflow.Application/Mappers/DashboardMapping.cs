using AutoMapper;
using Taskflow.Application.DTO.Project.Dasboard;
using Taskflow.Domain.Entities;
using Taskflow.Domain.Models.DAO;

namespace Taskflow.Application.Mappers;

public class DashboardMapping: Profile
{
    public DashboardMapping()
    {
        CreateMap<DashboardCreateDTO, DashboardEntity>()
            .ForMember(target => target.ProjectId, opt => opt.MapFrom(s => s.ProjectId))
            .ForMember(target => target.Index, opt => opt.MapFrom(s => s.Index))
            .ForMember(target => target.Title, option => option.MapFrom(source => source.Title));
        
        CreateMap<DashboardDTO, DashboardDAO>()
            .ForMember(target => target.Id, opt => opt.MapFrom(s => s.Id))
            .ForMember(target => target.Index, opt => opt.MapFrom(s => s.Index))
            .ForMember(target => target.Title, option => option.MapFrom(source => source.Title));

        CreateMap<DashboardEntity, DashboardGetDTO>()
            .ForMember(target => target.Id, opt => opt.MapFrom(source => source.Id))
            .ForMember(target => target.Title, opt => opt.MapFrom(source => source.Title));
    }
}