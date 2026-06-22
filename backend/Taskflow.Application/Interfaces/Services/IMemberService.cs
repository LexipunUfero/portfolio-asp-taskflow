using Taskflow.Application.DTO.Project.Member;
using Taskflow.Application.Response;
using Taskflow.Domain.Models.DAO;

namespace Taskflow.Application.Interfaces.Services;

public interface IMemberService
{
    Task<Result<Guid>> Create(ProjectMemberDAO settings, Guid userId);
    public Task<Result<List<MemberGetDTO>>> GetMembers(Guid projectId, Guid userId);
    public Task<Result<Guid>> RemoveMember(Guid id, Guid userId);
    public Task<Result<Guid>> UpdateMember(MemberUpdateDTO model, Guid userId);
    Task<Result<bool>> CheckDashboardEditAccess(Guid projectId, Guid userId);
}