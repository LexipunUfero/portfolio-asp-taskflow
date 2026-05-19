using Microsoft.EntityFrameworkCore;
using Taskflow.Application.Interfaces.Repositories;
using Taskflow.Domain.Entities;
using Taskflow.Infrastructure.Context;

namespace Taskflow.Infrastructure.Repositories;

public class UserRepository: IUserRepository
{
    private readonly TaskflowDbContext context;
    public UserRepository(TaskflowDbContext context)
    {
        this.context = context;
    }
    public async Task<UserPasswordEntity?> Get(string login)
    {
        var result = await context.UserPasswords
            .AsNoTracking()
            .FirstOrDefaultAsync(el=>el.Login == login);
        
        return result;
    }

    public async Task<Guid> Create(UserEntity entity, UserPasswordEntity passwordEntity)
    {
        entity.UserPassword = passwordEntity;
        entity.CreatedAt = DateTime.UtcNow;
        
        context.Users.Add(entity);
        await context.SaveChangesAsync();
        return entity.Id;
    }

    public async Task<UserPasswordEntity> Get(Guid userId)
    {
        var result = await context.UserPasswords
            .AsNoTracking()
            .FirstAsync(el=>el.UserId == userId);
        
        return result;
    }

    public async Task<UserEntity> GetUser(Guid userId)
    {
        var result = await context.Users
            .AsNoTracking()
            .FirstAsync(el=>el.Id == userId);
        
        return result;
    }

    public async Task<Guid> Update(UserEntity model)
    {
        var result = await context.Users
            .FirstAsync(el=>el.Id == model.Id);

        result.FileId = model.FileId;
        result.FirstName = model.FirstName;
        result.LastName = model.LastName;
        result.UpdatedAt = DateTime.UtcNow;
        result.UpdatedBy = model.Id;
        await  context.SaveChangesAsync();
        return result.Id;
    }
}