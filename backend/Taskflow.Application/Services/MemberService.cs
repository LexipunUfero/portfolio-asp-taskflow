using AutoMapper;
using Taskflow.Application.DTO.Project.Member;
using Taskflow.Application.Interfaces.Repositories;
using Taskflow.Application.Interfaces.Services;
using Taskflow.Application.Response;
using Taskflow.Domain.Entities;
using Taskflow.Domain.Models.DAO;

namespace Taskflow.Application.Services;

public class MemberService: IMemberService
{
    private readonly IMemberRepository repository;
    private readonly IMapper mapper;
    public MemberService(
        IMemberRepository repository,
        IMapper mapper)
    {
        this.repository = repository;
        this.mapper = mapper;
    }
    
    public async Task<Result<Guid>> Create(ProjectMemberDAO settings, Guid userId)
    {
        var member = new ProjectMemberEntity();
        member.UserId = userId;
        member.ProjectAccessId = settings.ProjectAccessId;
        member.ProjectId = settings.ProjectId;
        
        Guid id = await repository.Create(member);
        
        return Result<Guid>.Success(id);
    }
    
    public async Task<Result<List<MemberGetDTO>>> GetMembers(Guid projectId)
    {

        List<ProjectMemberEntity> entities = await repository.Get(projectId);
        var models = entities.Select(mapper.Map<MemberGetDTO>).ToList();
        
        return Result<List<MemberGetDTO>>.Success(models);
    }
    public async Task<Result<Guid>> RemoveMember(Guid id, Guid userId)
    {
        Guid resultId = await repository.Delete(id, userId);
        return Result<Guid>.Success(resultId);
    }
    
    public async Task<Result<Guid>> UpdateMember(MemberUpdateDTO model, Guid userId)
    {
        var entity = mapper.Map<ProjectMemberEntity>(model);
        Guid id = await repository.Update(entity, userId);
        return Result<Guid>.Success(id);
    }
}