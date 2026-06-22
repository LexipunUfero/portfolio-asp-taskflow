namespace Taskflow.Application.DTO.Project.links;

public class ProjectLinkSettingsDTO
{
    public Guid ProjectId { get; set; }
    public Guid AccessId { get; set; }
    public float LifeTime { get; set; }
}