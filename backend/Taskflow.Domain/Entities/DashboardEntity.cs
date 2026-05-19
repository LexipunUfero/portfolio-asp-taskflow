using Taskflow.Domain.Entities.Interface;

namespace Taskflow.Domain.Entities;

public class DashboardEntity: IEntity
{
    public string Title { get; set; }
    public int Index { get; set; }
    public Guid ProjectId { get; set; }
    
    #region dependencies
    
    public List<TaskEntity> Tasks { get; set; }
    public ProjectEntity Project { get; set; }
    
    #endregion
}