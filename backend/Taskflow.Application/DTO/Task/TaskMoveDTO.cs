namespace Taskflow.Application.DTO.Task;

public class TaskMoveDTO
{
    public Guid Id { get; set; }
    public Guid DashboardId { get; set; }
    public int Index {get; set;}
    public byte[] RowVersion { get; set; }
}