using Taskflow.Domain.Entities;

namespace Taskflow.Application.Interfaces.Repositories;

public interface IProjectAccessRepository
{
    Task<Guid> Create(ProjectAccessEntity entity, Guid userId);
    Task<Guid> Update(ProjectAccessEntity entity, Guid userId);
    Task<List<ProjectAccessEntity>> Get(Guid projectId);
    Task<Guid> Delete(Guid id, Guid userId);
}