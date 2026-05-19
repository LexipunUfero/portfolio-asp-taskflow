using AutoMapper;
using Taskflow.Application.DTO.Project;
using Taskflow.Domain.Entities;

namespace Taskflow.Application.Mappers;

public class ProjectMapping: Profile
{
    public ProjectMapping()
    {
        CreateMap<ProjectCreateDTO, ProjectEntity>()
            .ForMember(x => x.Name, opt => opt.MapFrom(src => src.Name));
        
        CreateMap< ProjectEntity,ProjectGetPreviewDTO>()
            .ForMember(x => x.Name, opt => opt.MapFrom(src => src.Name))
            .ForMember(x => x.Id, opt => opt.MapFrom(src => src.Id));

        CreateMap<ProjectEntity, ProjectGetDTO>()
            .ForMember(x => x.Id, opt => opt.MapFrom(src => src.Id))
            .ForMember(x => x.Name, opt => opt.MapFrom(src => src.Name))
            .ForMember(target => target.Dasboards, option => option.MapFrom(source => source.Dasboards));
        
    }
}