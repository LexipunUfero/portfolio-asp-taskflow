namespace Taskflow.Application.DTO.Comments;

public class CommentCreateDTO
{
    public string Content { get; set; }
    public IFormFile? Image { get; set; }
}