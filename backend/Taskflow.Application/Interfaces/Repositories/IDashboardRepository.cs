using Taskflow.Domain.Entities;
using Taskflow.Domain.Models.DAO;

namespace Taskflow.Application.Interfaces.Repositories;

public interface IDashboardRepository
{
    public Task<Guid> Create(DashboardEntity entity, Guid userId);
    Task Update(List<DashboardDAO> models, Guid projectId, Guid userId);
    Task<List<DashboardEntity>> Get(Guid projectId);
    Task<Guid> Delete(Guid id, Guid userId);
}