using Microsoft.EntityFrameworkCore;
using Taskflow.Application.Exceptions;
using Taskflow.Application.Interfaces.Repositories;
using Taskflow.Domain.Entities;
using Taskflow.Infrastructure.Context;

namespace Taskflow.Infrastructure.Repositories;

public class TaskRepository: ITaskRepository
{
    private readonly TaskflowDbContext context;
    public TaskRepository(TaskflowDbContext context)
    {
        this.context = context;
    }
    public async Task<Guid> Create(TaskEntity entity, List<Guid> modelMarkdowns, Guid userId)
    {

        entity.Markdowns = modelMarkdowns.Select(el =>
            new TaskMarkDownEntity()
            {
                MarkDownId = el
            }).ToList();
        
        await context.Tasks.AddAsync(entity); 
        await  context.SaveChangesAsync();
        return entity.Id;
    }

    public async Task<Guid> Update(TaskEntity entity, List<Guid> modelMarkdowns, Guid userId)
    {
        var trackedEntity = await context.Tasks
            .Include(el=>el.Markdowns)
            .FirstAsync(el => el.Id == entity.Id);
        
        trackedEntity.UpdatedBy = userId;
        trackedEntity.UpdatedAt = DateTime.UtcNow;
        trackedEntity.EndDate = entity.EndDate;
        trackedEntity.Name = entity.Name;
        trackedEntity.Description = entity.Description;
        trackedEntity.DashboardId = entity.DashboardId;
        trackedEntity.RowVersion = entity.RowVersion;
        
        var newTaskMarkdown = modelMarkdowns
            .Where(el => !trackedEntity.Markdowns.Exists(key => key.MarkDownId == el))
            .Select(el => new TaskMarkDownEntity()
            {
                MarkDownId = el
            }).ToList();
        trackedEntity.Markdowns.AddRange(newTaskMarkdown);
        var removeTaskMarkdowns =  trackedEntity.Markdowns.Where(key=>!modelMarkdowns.Contains(key.MarkDownId));
        context.TaskMarkDowns.RemoveRange(removeTaskMarkdowns);
        
        if (trackedEntity.Index > entity.Index)
        {
            var dependentTasks = await context.Tasks
                .Where(el => el.Index >= entity.Index
                             && el.Index < trackedEntity.Index
                             && el.DashboardId == trackedEntity.DashboardId
                             && !el.IsDeleted)
                .ExecuteUpdateAsync(s => s.SetProperty(x => x.Index, x => x.Index + 1));

           
        }else if (trackedEntity.Index < entity.Index)
        {
            var dependentTasks = await context.Tasks
                .Where(el=>el.Index > trackedEntity.Index
                           && el.Index <= entity.Index
                           && el.DashboardId == trackedEntity.DashboardId
                           && !el.IsDeleted)
                .ExecuteUpdateAsync(s => s.SetProperty(x => x.Index, x => x.Index - 1));
        }
        trackedEntity.Index = entity.Index;
        try
        {
            await context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            throw new ConcurrencyException();
        }
        return trackedEntity.Id;
    }

    public async Task<List<TaskEntity>> Get(Guid projectId)
    {
        var result = await context.Tasks
            .AsNoTracking()
            .Include(el => el.Markdowns)
            .ThenInclude(markdown => markdown.Markdown)
            .Include(el => el.Dashboard)
            .Where(el => el.Dashboard.ProjectId == projectId
                         && !el.IsDeleted)
            .ToListAsync();
        return result;
    }

    public async Task<TaskEntity> GetById(Guid id)
    {
        var result = await context.Tasks
            .AsNoTracking()
            .Include(el => el.Markdowns)
            .ThenInclude(markdown => markdown.Markdown)
            .FirstAsync(el => el.Id == id);

        return result;
    }

    public async Task<Guid> Delete(Guid id, Guid userId)
    {
        var entity = await context.Tasks
            .FirstAsync(el => el.Id == id);
        
        entity.IsDeleted =  true;
        entity.UpdatedAt = DateTime.UtcNow;
        entity.UpdatedBy = userId;

        await context.SaveChangesAsync();
        return entity.Id;
    }
}