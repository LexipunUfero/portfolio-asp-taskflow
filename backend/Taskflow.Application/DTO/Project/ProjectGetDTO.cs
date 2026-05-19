using Taskflow.Application.DTO.Project.Dasboard;

namespace Taskflow.Application.DTO.Project;

public class ProjectGetDTO
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public List<DashboardGetDTO> Dasboards { get; set; }
}