using Taskflow.Domain.Entities.Interface;

namespace Taskflow.Domain.Entities;

public class ProjectAccessEntity: IEntity
{
    public Guid ProjectId { get; set; }
    public string Name { get; set; }
    public bool IsOwner { get; set; }
    public bool CanManageUsers { get; set; }
    public bool CanCreateTasks { get; set; }
    public bool CanUpdateTasks { get; set; }
    public bool CanRemoveTasks { get; set; }
    public bool IsDeleted { get; set; }

    #region dependencies

    public ProjectEntity? Project { get; set; }
    public List<ProjectMemberEntity>? ProjectMembers { get; set; }
    public List<ProjectAccessEntity>? ProjectAccesses { get; set; }
    public List<LinkEntity>? Links { get; set; }
    #endregion
}