namespace Taskflow.Application.DTO.Project.Access;

public class ProjectAccessGetPreviewDTO
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public bool IsOwner { get; set; }
}