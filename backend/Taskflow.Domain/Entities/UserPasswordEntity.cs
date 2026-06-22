using Taskflow.Domain.Entities.Interface;

namespace Taskflow.Domain.Entities;

public class UserPasswordEntity: IEntity
{
    public Guid UserId { get; set; }
    public string Login { get; set; }
    public string Password { get; set; }
    public string Salt { get; set; }

    #region dependencies

    public UserEntity User { get; set; }

    #endregion
}