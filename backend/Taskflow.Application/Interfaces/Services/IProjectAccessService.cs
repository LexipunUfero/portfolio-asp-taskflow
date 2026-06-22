using Taskflow.Application.DTO.Project.Access;
using Taskflow.Application.Response;

namespace Taskflow.Application.Interfaces.Services;

public interface IProjectAccessService
{
    public Task<Result<Guid>> Create(ProjectAccessCreateDTO model, Guid userId);
    public Task<Result<Guid>> Update(ProjectAccessUpdateDTO model, Guid userId);
    public Task<Result<List<ProjectAccessGetDTO>>> Get(Guid projectId);
    public Task<Result<Guid>> Delete(Guid id, Guid userId);
}