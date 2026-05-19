namespace Taskflow.Application.DTO.User;

public class UserUpdateDTO
{
    public Guid Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public IFormFile? Image { get; set; }
    public Guid? FileId { get; set; }
}