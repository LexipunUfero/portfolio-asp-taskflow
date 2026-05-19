namespace Taskflow.Application.DTO.Autentication;

public class RegisterDTO
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    
    public string Login { get; set; }
    public string Password { get; set; }
    
    public IFormFile? Image { get; set; }
}