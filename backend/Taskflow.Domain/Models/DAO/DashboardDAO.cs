namespace Taskflow.Domain.Models.DAO;

public class DashboardDAO
{
    public Guid? Id { get; set; }
    public Guid? ProjectId { get; set; }
    public int? Index { get; set; }
    public string? Title { get; set; }
}