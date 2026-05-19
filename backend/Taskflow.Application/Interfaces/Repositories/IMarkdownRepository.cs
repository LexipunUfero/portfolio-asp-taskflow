using Taskflow.Domain.Entities;

namespace Taskflow.Application.Interfaces.Repositories;

public interface IMarkdownRepository
{
public Task<Guid> Create(MarkdownEntity entity, Guid userId);
Task<Guid> Update(MarkdownEntity entity, Guid userId);
Task<Guid> Delete(Guid id, Guid userId);
Task<List<MarkdownEntity>> Get(Guid projectId);
}