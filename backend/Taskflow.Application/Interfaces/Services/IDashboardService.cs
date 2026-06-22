using Taskflow.Application.DTO.Project.Dasboard;
using Taskflow.Application.Response;
using Taskflow.Domain.Models.Configs;

namespace Taskflow.Application.Interfaces.Services;

public interface IDashboardService
{
    Task<Result<Guid>> Create(DashboardCreateDTO model, Guid userId);
    Task<Result<Guid>> Update(DashboardUpdateDTO source, Guid userId);
    Task<Result<List<DashboardGetDTO>>> Get(Guid projectId);
    Task<Result<Guid>> Delete(Guid id, Guid userId);
    Task<Result<bool>> Create(List<DashboardConfigs> configsBoardConfigs, Guid entityId, Guid userId);
}