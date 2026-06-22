namespace Taskflow.Domain.Entities.Interface;

public abstract class IEntity
{
    public Guid Id { get; set; }
    public DateTime CreatedAt { get; set; }
    public Guid? CreatedBy { get; set; }
    public DateTime UpdatedAt { get; set; }
    public Guid UpdatedBy { get; set; }
}