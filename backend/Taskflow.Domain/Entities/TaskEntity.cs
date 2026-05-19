using System.ComponentModel.DataAnnotations;
using Taskflow.Domain.Entities.Interface;

namespace Taskflow.Domain.Entities;

public class TaskEntity: IEntity
{
    public string Name { get; set; }
    public string Description { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public int Index { get; set; }
    public Guid DashboardId { get; set; }
    
    public bool IsDeleted { get; set; }
    
    [Timestamp]
    public byte[] RowVersion { get; set; }

    #region dependencies

    public List<TaskMarkDownEntity> Markdowns { get; set; }
    public List<CommentEntity> Comments { get; set; }
    public DashboardEntity Dashboard { get; set; }

    #endregion
}