using Taskflow.Domain.Entities;

namespace Taskflow.Application.Interfaces.Repositories;

public interface IFileRepository
{
    Task<Guid> Create(IFormFile image, string fileName, Guid? userId);
    Task<FileEntity> Get(Guid fileId);
}