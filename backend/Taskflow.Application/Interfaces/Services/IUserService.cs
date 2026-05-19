using Taskflow.Application.DTO.User;
using Taskflow.Application.Response;

namespace Taskflow.Application.Interfaces.Services;

public interface IUserService
{
    public Task<Result<Guid>> Update(UserUpdateDTO model);
    public Task<Result<UserGetDTO>> Get(Guid id);
}