using Taskflow.Application.DTO.Task;
using Taskflow.Application.Response;

namespace Taskflow.Application.Interfaces.Services;

public interface ITaskService
{
    public Task<Result<Guid>> Create(TaskCreateDTO model, Guid userId);
    public Task<Result<Guid>> Update(TaskUpdateDTO model, Guid userId);
    public Task<Result<List<TaskGetDTO>>> Get(Guid projectId);
    public Task<Result<TaskGetDTO>> GetById(Guid id);
    public Task<Result<Guid>> Delete(Guid id, Guid userId);
    Task<Result<Guid>> Move(TaskMoveDTO model, Guid userId);
    Task<Result<Guid>> AttachMarkdown(TaskAttachMarkdown model, Guid userId);
    Task<Result<Guid>> DeattachMarkdown(TaskAttachMarkdown model, Guid userId);
}