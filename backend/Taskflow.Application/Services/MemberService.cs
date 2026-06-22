using AutoMapper;
using Microsoft.Extensions.Options;
using Taskflow.Application.DTO.Project.Member;
using Taskflow.Application.Interfaces.Repositories;
using Taskflow.Application.Interfaces.Services;
using Taskflow.Application.Response;
using Taskflow.Domain.Entities;
using Taskflow.Domain.Models.Configs;
using Taskflow.Domain.Models.DAO;

namespace Taskflow.Application.Services;

public class MemberService: IMemberService
{
    private readonly IMemberRepository repository;
    private readonly IMapper mapper;
    private readonly ErrorMessages errorMessages;
    public MemberService(
        IMemberRepository repository,
        IMapper mapper,
        IOptions<ErrorMessages> errorMessages)
    {
        this.repository = repository;
        this.mapper = mapper;
        this.errorMessages = errorMessages.Value;
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

    public async Task<Result<bool>> CheckDashboardEditAccess(Guid projectId, Guid userId)
    {
        var member = await repository.GetMemberByProjectId(projectId, userId);

        if (member == null || !member.ProjectAccess.CanUpdateTasks)
        {
            return Result<bool>.Fail(errorMessages.AccessDenied);
        }
        
        return Result<bool>.Success(true);
    }
    
    public async Task<Result<List<MemberGetDTO>>> GetMembers(Guid projectId, Guid userId)
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