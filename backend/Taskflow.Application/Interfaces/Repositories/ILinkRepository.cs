using Taskflow.Domain.Entities;

namespace Taskflow.Application.Interfaces.Repositories;

public interface ILinkRepository
{
    Task<Guid> Create(LinkEntity entity, Guid userId);
    Task AddUser(string linkId, Guid userId);
}