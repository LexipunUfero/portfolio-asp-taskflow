using Taskflow.Domain.Entities.Interface;

namespace Taskflow.Domain.Entities;

public class MarkdownEntity: IEntity
{
    public string Color { get; set; }
    public string Name { get; set; }
    public Guid ProjectId { get; set; }

    #region dependencies

    public List<TaskMarkDownEntity> Tasks { get; set; }
    public ProjectEntity Project { get; set; }

    #endregion
}