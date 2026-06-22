using Taskflow.Domain.Entities.Interface;

namespace Taskflow.Domain.Entities;

public class UserEntity: IEntity
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public Guid UserPasswordId { get; set; }
    public Guid? FileId { get; set; }

    #region dependencies

    public UserPasswordEntity UserPassword { get; set; }
    public FileEntity? File { get; set; }
    public List<ProjectMemberEntity> ProjectMembers { get; set; }
    public List<LinkUserEntity>  LinkUsers { get; set; }
    public List<CommentEntity> Comments { get; set; }

    #endregion
}