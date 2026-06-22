using Taskflow.Application.DTO.Project.links;
using Taskflow.Application.Response;

namespace Taskflow.Application.Interfaces.Services;

public interface ILinkService
{
    public Task<Result<string>> Create(ProjectLinkSettingsDTO model, Guid userId);
    public Task<Result<Guid>> Enter(string linkId, Guid userId);
}