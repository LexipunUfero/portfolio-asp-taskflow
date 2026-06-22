using Taskflow.Domain.Entities;

namespace Taskflow.Application.Interfaces.Repositories;

public interface ICommentRepository
{
    Task<Guid> Create(Guid taskId,string content, Guid? fileId, Guid userId);
    Task<List<CommentEntity>> Get(Guid taskId);
    Task<CommentEntity> GetById(Guid id);
    Task<Guid> Delete(Guid id, Guid userId);
    Task<Guid> Update(CommentEntity entity, Guid userId);
}