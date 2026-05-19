using Taskflow.Domain.Entities;

namespace Taskflow.Application.Interfaces.Repositories;

public interface IDashboardRepository
{
    public Task<Guid> Create(DashboardEntity entity, Guid userId);
    Task<Guid> Update(DashboardEntity entity, Guid userId);
    Task<List<DashboardEntity>> Get(Guid projectId);
    Task<Guid> Delete(Guid id, Guid userId);
}