using DevOne.Security.Cryptography.BCrypt;

namespace Taskflow.Application.Validators;

public class HashManager
{
    public string GenerateSalt()
    {
        return BCryptHelper.GenerateSalt();
    }

    public string HashPassword(string password, string salt)
    {
        return BCryptHelper.HashPassword(password, salt);
    }

    public bool VerifyPassword(string password, string hashedPassword)
    {
        return BCryptHelper.CheckPassword(password, hashedPassword);
    }
}