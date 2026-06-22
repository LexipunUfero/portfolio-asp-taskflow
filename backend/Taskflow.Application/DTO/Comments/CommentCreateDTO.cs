namespace Taskflow.Application.DTO.Comments;

public class CommentCreateDTO
{
    public Guid TaskId { get; set; }
    public string Content { get; set; }
    public IFormFile? Image { get; set; }
}