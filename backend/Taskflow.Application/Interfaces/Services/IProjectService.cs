using Taskflow.Application.DTO.Project;
using Taskflow.Application.Response;

namespace Taskflow.Application.Interfaces.Services;

public interface IProjectService
{
    public Task<Result<Guid>> Create(ProjectCreateDTO model, Guid userId);
    public Task<Result<List<ProjectGetPreviewDTO>>> Get(Guid userid);
    public Task<Result<ProjectGetDTO>> GetById(Guid id);
}