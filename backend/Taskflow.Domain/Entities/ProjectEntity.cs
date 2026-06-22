using Taskflow.Domain.Entities.Interface;

namespace Taskflow.Domain.Entities;

public class ProjectEntity: IEntity
{
    public string Name { get; set; }

    #region dependencies

    public List<DashboardEntity> Dasboards { get; set; }
    public List<MarkdownEntity> Markdowns { get; set; }
    public List<ProjectMemberEntity> ProjectMembers { get; set; }
    public List<ProjectAccessEntity> ProjectAccesses { get; set; }
    public List<LinkEntity> Links { get; set; }

    #endregion
}