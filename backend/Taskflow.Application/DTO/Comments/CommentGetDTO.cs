namespace Taskflow.Application.DTO.Comments;

public class CommentGetDTO
{
    public Guid Id { get; set; }
    public string Content { get; set; }
    public Guid FileId { get; set; }
    public DateTime Created { get; set; }
    public DateTime Updated { get; set; }
    public Guid UserId { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
}