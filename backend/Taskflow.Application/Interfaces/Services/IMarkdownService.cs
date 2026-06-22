using Taskflow.Application.DTO.Markdown;
using Taskflow.Application.Response;

namespace Taskflow.Application.Interfaces.Services;

public interface IMarkdownService
{
    public Task<Result<Guid>> Create(MarkdownCreateDTO model, Guid userId);
    public Task<Result<Guid>> Update(MarkdownUpdateDTO model, Guid userId);
    public Task<Result<List<MarkdownGetDTO>>> Get(Guid projectId);
    public Task<Result<Guid>> Delete(Guid id, Guid userId);
}