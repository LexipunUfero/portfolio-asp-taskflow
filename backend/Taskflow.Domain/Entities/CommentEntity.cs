using Taskflow.Domain.Entities.Interface;

namespace Taskflow.Domain.Entities;

public class CommentEntity: IEntity
{
    public string Content { get; set; }
    public Guid TaskId { get; set; }
    public Guid? FileId { get; set; }

    #region dependencies

    public TaskEntity Task { get; set; }
    public FileEntity? File { get; set; }
    public UserEntity User { get; set; }
    #endregion
}