namespace Taskflow.Domain.Entities;

public class LinkEntity
{
    public Guid Id { get; set; }
    public DateTime CreatedAt { get; set; }
    public Guid CreatedBy { get; set; }
    public Guid? ProjectAccessId { get; set; }
    public Guid ProjectId { get; set; }
    public float LifeTime { get; set; }
    public string Key {get; set;}

    #region depencies

    public List<LinkUserEntity> LinkUsers { get; set; }
    public ProjectEntity Poject { get; set; }
    public ProjectAccessEntity ProjectAccess { get; set; }

    #endregion
}