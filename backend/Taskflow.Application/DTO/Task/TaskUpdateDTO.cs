namespace Taskflow.Application.DTO.Task;

public class TaskUpdateDTO
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public DateTime DateStart { get; set; }
    public DateTime DateEnd { get; set; }
    public Guid DashboardId  { get; set; }
    public int Index { get; set; }
    public byte[] RowVersion { get; set; }
}