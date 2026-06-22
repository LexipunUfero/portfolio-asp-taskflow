using AutoMapper;
using Taskflow.Application.DTO.Project.links;
using Taskflow.Domain.Models.DAO;

namespace Taskflow.Application.Mappers;

public class LinkMapping: Profile
{
    public LinkMapping()
    {
        CreateMap<ProjectLinkSettingsDTO, ProjectMemberDAO>()
            .ForMember(model => model.ProjectId, opts => opts.MapFrom(src => src.ProjectId))
            .ForMember(model => model.ProjectAccessId, opts => opts.MapFrom(src => src.AccessId));
    }
}