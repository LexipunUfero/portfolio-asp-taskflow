using Taskflow.Application.DTO.Task;
using Taskflow.Domain.Entities;

namespace Taskflow.Application.Interfaces.Repositories;

public interface ITaskRepository
{
    Task<Guid> Create(TaskEntity entity, Guid userId);
    Task<Guid> Update(TaskEntity entity, Guid userId);
    Task<List<TaskEntity>> Get(Guid projectId);
    Task<TaskEntity> GetById(Guid id);
    Task<Guid> Delete(Guid id, Guid userId);
    Task<Guid> Move(TaskMoveDTO model, Guid userId);
    Task<Guid> AttachMarkdown(TaskAttachMarkdown model, Guid userId);
    Task<Guid> DeattachMarkdown(TaskAttachMarkdown model, Guid userId);
}