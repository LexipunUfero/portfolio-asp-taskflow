namespace Taskflow.Application.DTO.Project.Dasboard;

public class DashboardUpdateDTO
{
    public List<DashboardDTO> Dashboards { get; set; }
    public Guid ProjectId { get; set; }
}