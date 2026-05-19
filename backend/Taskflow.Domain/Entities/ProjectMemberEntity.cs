using Taskflow.Domain.Entities.Interface;

namespace Taskflow.Domain.Entities;

public class ProjectMemberEntity: IEntity
{
    public Guid Id { get; set; }
    public Guid ProjectId { get; set; }
    public Guid? UserId { get; set; }
    public Guid? ProjectAccessId  { get; set; }
    

    #region dependencies

    public ProjectEntity Project { get; set; }
    public UserEntity? User { get; set; }
    public ProjectAccessEntity? ProjectAccess { get; set; }

    #endregion
}