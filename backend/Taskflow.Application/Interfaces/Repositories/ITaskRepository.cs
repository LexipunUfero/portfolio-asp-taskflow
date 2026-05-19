using Taskflow.Domain.Entities;

namespace Taskflow.Application.Interfaces.Repositories;

public interface ITaskRepository
{
    Task<Guid> Create(TaskEntity entity, List<Guid> modelMarkdowns, Guid userId);
    Task<Guid> Update(TaskEntity entity, List<Guid> modelMarkdowns, Guid userId);
    Task<List<TaskEntity>> Get(Guid projectId);
    Task<TaskEntity> GetById(Guid id);
    Task<Guid> Delete(Guid id, Guid userId);
}