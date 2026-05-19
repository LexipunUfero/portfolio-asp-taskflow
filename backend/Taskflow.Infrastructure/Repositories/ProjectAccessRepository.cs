using Microsoft.EntityFrameworkCore;
using Taskflow.Application.Interfaces.Repositories;
using Taskflow.Domain.Entities;
using Taskflow.Infrastructure.Context;

namespace Taskflow.Infrastructure.Repositories;

public class ProjectAccessRepository: IProjectAccessRepository
{
    private readonly TaskflowDbContext context;
    public ProjectAccessRepository(TaskflowDbContext context)
    {
        this.context = context;
    }
    public async Task<Guid> Create(ProjectAccessEntity entity, Guid userId)
    {
        entity.CreatedAt = DateTime.UtcNow;
        entity.CreatedBy = userId;
        await  context.AddAsync(entity);
        await context.SaveChangesAsync();
        return entity.Id;
    }

    public async Task<Guid> Update(ProjectAccessEntity entity, Guid userId)
    {
        var trackedEntity = await context.ProjectAccesses
            .FirstAsync(el=> el.Id == entity.Id);
        trackedEntity.UpdatedAt = DateTime.UtcNow;
        trackedEntity.UpdatedBy = userId;
        trackedEntity.Name = entity.Name;
        trackedEntity.CanRemoveTasks = entity.CanRemoveTasks;
        trackedEntity.CanUpdateTasks = entity.CanUpdateTasks;
        trackedEntity.CanCreateTasks = entity.CanCreateTasks;
        trackedEntity.CanManageUsers = entity.CanManageUsers;
        await context.SaveChangesAsync();
        return trackedEntity.Id;
    }

    public async Task<List<ProjectAccessEntity>> Get(Guid projectId)
    {
        var result = await context.ProjectAccesses
            .AsNoTracking()
            .Where(el => el.ProjectId == projectId
                         && el.IsDeleted == false)
            .ToListAsync();
        return result;
        
    }

    public async Task<Guid> Delete(Guid id, Guid userId)
    {
        var trackedEntity = await context.ProjectAccesses
            .FirstAsync(el=> el.Id == id);

        trackedEntity.IsDeleted = true;
        trackedEntity.UpdatedBy = userId;
        trackedEntity.UpdatedAt = DateTime.UtcNow;
        
        return trackedEntity.Id;
    }
}