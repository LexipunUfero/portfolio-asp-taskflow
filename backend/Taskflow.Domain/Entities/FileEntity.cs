using Taskflow.Domain.Entities.Interface;

namespace Taskflow.Domain.Entities;

public class FileEntity: IEntity
{
    public string FileName { get; set; }
    public string ContentType { get; set; }

    #region dependencies

    public CommentEntity? Comment { get; set; }
    public UserEntity? User { get; set; }

    #endregion
}