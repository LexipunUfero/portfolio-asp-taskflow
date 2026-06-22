using Taskflow.Application.DTO.Markdown;

namespace Taskflow.Application.DTO.Task;

public class TaskGetDTO
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public List<MarkdownGetDTO> Labels { get; set; }
    public string Description { get; set; }
    public DateTime DateStart { get; set; }
    public DateTime DateEnd { get; set; }
    public Guid DashboardId { get; set; }
    public int Index { get; set; }
    public byte[] RowVersion { get; set; }
}