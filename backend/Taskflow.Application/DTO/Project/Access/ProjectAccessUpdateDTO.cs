namespace Taskflow.Application.DTO.Project.Access;

public class ProjectAccessUpdateDTO
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public bool IsOwner { get; set; }
    public bool CanManageUsers { get; set; }
    public bool CanCreateTasks { get; set; }
    public bool CanUpdateTasks { get; set; }
    public bool CanRemoveTasks { get; set; }
}