namespace Taskflow.Application.DTO.Project.Dasboard;

public class DashboardCreateDTO
{
    public Guid ProjectId { get; set; }
    public string Title { get; set; }
    public int Index { get; set; }
}