namespace Taskflow.Application.DTO.Comments;

public class CommentUpdateDTO
{
    public Guid Id { get; set; }
    public string? Content { get; set; }
    public Guid? FileId { get; set; }
    public IFormFile? Image { get; set; }
}