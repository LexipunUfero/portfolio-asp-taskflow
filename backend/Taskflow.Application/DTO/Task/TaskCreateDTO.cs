namespace Taskflow.Application.DTO.Task;

public class TaskCreateDTO
{
    public string Name { get; set; }
    public Guid DashboardId  { get; set; }
    public int Index { get; set; }
}