using Taskflow.Application.DTO.Markdown;

namespace Taskflow.Application.DTO.Task;

public class TaskGetDTO
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public List<MarkdownGetDTO> Markdowns { get; set; }
    public string Description { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public Guid DashboardId { get; set; }
    public int Index { get; set; }
    public byte[] RowVersion { get; set; }
}