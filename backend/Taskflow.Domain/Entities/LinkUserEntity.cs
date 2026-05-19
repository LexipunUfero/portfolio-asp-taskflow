namespace Taskflow.Domain.Entities;

public class LinkUserEntity
{
    public Guid Id { get; set; }
    public Guid LinkId { get; set; }
    public Guid? UserId { get; set; }

    #region dependencies

    public LinkEntity Link { get; set; }
    public UserEntity User { get; set; }

    #endregion
}