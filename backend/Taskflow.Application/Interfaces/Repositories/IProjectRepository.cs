using Taskflow.Domain.Entities;

namespace Taskflow.Application.Interfaces.Repositories;

public interface IProjectRepository
{
    Task<Guid> Create(ProjectEntity entity, Guid userId);
    Task<List<ProjectEntity>> Get(Guid userid);
    Task<ProjectEntity> GetById(Guid id);
}