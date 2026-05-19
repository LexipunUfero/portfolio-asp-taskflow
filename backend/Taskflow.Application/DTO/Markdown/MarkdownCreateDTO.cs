namespace Taskflow.Application.DTO.Markdown;

public class MarkdownCreateDTO
{
    public string? Title { get; set; }
    public string Color { get; set; }
    public Guid ProjectId { get; set; }
}