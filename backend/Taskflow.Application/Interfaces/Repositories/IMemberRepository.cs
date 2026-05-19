using Taskflow.Application.DTO.Project.Member;
using Taskflow.Domain.Entities;

namespace Taskflow.Application.Interfaces.Repositories;

public interface IMemberRepository
{
    Task<Guid> Create(ProjectMemberEntity member);
    Task<List<ProjectMemberEntity>> Get(Guid projectId);
    Task<Guid> Delete(Guid id, Guid userId);
    Task<Guid> Update(ProjectMemberEntity entity, Guid userId);
}