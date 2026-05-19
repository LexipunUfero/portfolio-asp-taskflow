using Taskflow.Application.DTO.User;
using Taskflow.Domain.Entities;

namespace Taskflow.Application.Interfaces.Repositories;

public interface IUserRepository
{
    Task<UserPasswordEntity?> Get(string login);
    Task<Guid> Create(UserEntity entity, UserPasswordEntity passwordEntity);
    Task<UserPasswordEntity> Get(Guid userId);
    Task<UserEntity> GetUser(Guid userId);
    Task<Guid> Update(UserEntity model);
}