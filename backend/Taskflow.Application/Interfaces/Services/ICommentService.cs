using Taskflow.Application.DTO.Comments;
using Taskflow.Application.Response;

namespace Taskflow.Application.Interfaces.Services;

public interface ICommentService
{
    public Task<Result<Guid>> Create(CommentCreateDTO model, Guid userId);
    public Task<Result<Guid>> Update(CommentUpdateDTO model, Guid userId);
    public Task<Result<Guid>> Delete(Guid id, Guid userId);
    public Task<Result<List<CommentGetDTO>>> Get(Guid taskId);
}