namespace Taskflow.Application.DTO.Task;

public class TaskCreateDTO
{
    public string Name { get; set; }
    public string Description { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public Guid ProjectId { get; set; }
    public List<Guid> Markdowns  { get; set; }
    public Guid DashboardId  { get; set; }
    public int Index { get; set; }
}