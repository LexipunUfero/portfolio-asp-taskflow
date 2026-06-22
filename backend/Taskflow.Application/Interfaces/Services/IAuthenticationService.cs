using Taskflow.Application.DTO.Autentication;
using Taskflow.Application.DTO.User;
using Taskflow.Application.Response;

namespace Taskflow.Application.Interfaces.Services;

public interface IAuthenticationService
{
    public Task<Result<string>> Login(LoginDTO model);
    public Task<Result<Guid>> Create(RegisterDTO model);
    public Task<Result<Guid>> Update(UserPasswordUpdateDTO model, Guid userId);
}