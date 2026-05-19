using Taskflow.Domain.Entities.Interface;

namespace Taskflow.Domain.Entities;

public class TaskMarkDownEntity: IEntity
{
    public Guid TaskId { get; set; }
    public Guid MarkDownId { get; set; }

    #region dependencies
    
    public TaskEntity Task { get; set; }
    public MarkdownEntity Markdown { get; set; }
    
    #endregion
}