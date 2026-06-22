using AutoMapper;
using Taskflow.Application.DTO.Project.Member;
using Taskflow.Domain.Entities;

namespace Taskflow.Application.Mappers;

public class MemberMapping: Profile
{
    public MemberMapping()
    {
        CreateMap<MemberUpdateDTO, ProjectMemberEntity>()
            .ForMember(model => model.Id, opts => opts.MapFrom(src => src.Id))
            .ForMember(target => target.UserId, option => option.MapFrom(source => source.UserId))
            .ForMember(target => target.ProjectAccessId, opts => opts.MapFrom(src => src.AccessId));

        CreateMap<ProjectMemberEntity, MemberGetDTO>()
            .ForMember(target => target.Id, opts => opts.MapFrom(src => src.Id))
            .ForMember(target => target.Added, option => option.MapFrom(source => source.CreatedAt))
            .ForMember(target => target.FirstName, option => option.MapFrom(source => source.User.FirstName))
            .ForMember(target => target.LastName, option => option.MapFrom(source => source.User.LastName))
            .ForMember(target => target.ImageId, option => option.MapFrom(source => source.User.FileId))
            .ForMember(target => target.Access, option => option.MapFrom(source => source.ProjectAccess));
    }
}