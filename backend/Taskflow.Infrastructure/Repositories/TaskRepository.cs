using Microsoft.EntityFrameworkCore;
using Taskflow.Application.DTO.Task;
using Taskflow.Application.Exceptions;
using Taskflow.Application.Interfaces.Repositories;
using Taskflow.Domain.Entities;
using Taskflow.Infrastructure.Context;

namespace Taskflow.Infrastructure.Repositories;

public class TaskRepository : ITaskRepository
{
    private readonly TaskflowDbContext context;

    public TaskRepository(TaskflowDbContext context)
    {
        this.context = context;
    }

    public async Task<Guid> Create(TaskEntity entity, Guid userId)
    {
        await context.Tasks.Where(el => el.DashboardId == entity.DashboardId)
            .ExecuteUpdateAsync(s => s.SetProperty(x => x.Index, x => x.Index + 1));

        entity.Description = string.Empty;
        await context.Tasks.AddAsync(entity);
        await context.SaveChangesAsync();
        return entity.Id;
    }

    public async Task<Guid> Update(TaskEntity entity, Guid userId)
    {
        var trackedEntity = await context.Tasks
            .Include(el => el.Markdowns)
            .FirstAsync(el => el.Id == entity.Id);

        trackedEntity.UpdatedBy = userId;
        trackedEntity.UpdatedAt = DateTime.UtcNow;
        trackedEntity.EndDate = entity.EndDate;
        trackedEntity.StartDate = entity.StartDate;
        trackedEntity.Name = entity.Name;
        trackedEntity.Description = entity.Description;
        trackedEntity.RowVersion = entity.RowVersion;

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

        entity.IsDeleted = true;
        entity.UpdatedAt = DateTime.UtcNow;
        entity.UpdatedBy = userId;

        await context.SaveChangesAsync();
        return entity.Id;
    }

    public async Task<Guid> Move(TaskMoveDTO model, Guid userId)
    {
        var entity = await context.Tasks
            .FirstAsync(el => el.Id == model.Id);

        if (entity.DashboardId != model.DashboardId)
        {
            entity.DashboardId = model.DashboardId;
            await context.Tasks.Where(el =>
                    el.DashboardId == model.DashboardId && el.Index >= model.Index)
                .ExecuteUpdateAsync(s => s.SetProperty(x => x.Index, x => x.Index + 1));
        }
        else if (entity.Index < model.Index)
        {
            await context.Tasks.Where(el =>
                    el.DashboardId == model.DashboardId && el.Index > entity.Index && el.Index <= model.Index)
                .ExecuteUpdateAsync(s => s.SetProperty(x => x.Index, x => x.Index - 1));
        }
        else
        {
            await context.Tasks.Where(el =>
                    el.DashboardId == model.DashboardId && el.Index < entity.Index && el.Index >= model.Index)
                .ExecuteUpdateAsync(s => s.SetProperty(x => x.Index, x => x.Index + 1));
        }

        entity.Index = model.Index;
        entity.UpdatedBy = userId;
        entity.UpdatedAt = DateTime.UtcNow;

        await context.SaveChangesAsync();
        return entity.Id;
    }

    public async Task<Guid> AttachMarkdown(TaskAttachMarkdown model, Guid userId)
    {
        var result = await context.TaskMarkDowns.AddAsync(new TaskMarkDownEntity()
        {
            MarkDownId = model.LabelId,
            TaskId = model.Id,
            CreatedBy = userId,
            CreatedAt = DateTime.UtcNow,
        });
        await context.SaveChangesAsync();
        return result.Entity.Id;
    }

    public async Task<Guid> DeattachMarkdown(TaskAttachMarkdown model, Guid userId)
    {
        var entity =
            await context.TaskMarkDowns.FirstAsync(el => el.TaskId == model.Id && el.MarkDownId == model.LabelId);
        context.Remove(entity);
        await context.SaveChangesAsync();
        return entity.Id;
    }
}