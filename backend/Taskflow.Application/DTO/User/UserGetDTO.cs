namespace Taskflow.Application.DTO.User;

public class UserGetDTO
{
    public Guid Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public Guid ImageId { get; set; }
}