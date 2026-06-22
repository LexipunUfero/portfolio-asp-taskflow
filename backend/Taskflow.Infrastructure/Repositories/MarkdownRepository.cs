using Microsoft.EntityFrameworkCore;
using Taskflow.Application.Interfaces.Repositories;
using Taskflow.Domain.Entities;
using Taskflow.Infrastructure.Context;

namespace Taskflow.Infrastructure.Repositories;

public class MarkdownRepository: IMarkdownRepository
{
    private readonly TaskflowDbContext context;
    public MarkdownRepository(TaskflowDbContext context)
    {
        this.context = context;
    }
    public async Task<Guid> Create(MarkdownEntity entity, Guid userId)
    {
        entity.CreatedAt = DateTime.UtcNow;
        entity.CreatedBy = userId;
        await context.Markdowns.AddAsync(entity);
        await context.SaveChangesAsync();
        
        return entity.Id;
    }

    public async Task<Guid> Update(MarkdownEntity entity, Guid userId)
    {
        var trackedEntity = await context.Markdowns.FirstAsync(e => e.Id == entity.Id);
        trackedEntity.UpdatedAt = DateTime.UtcNow;
        trackedEntity.UpdatedBy = userId;
        trackedEntity.Name = entity.Name;
        trackedEntity.Color = entity.Color;
        await context.SaveChangesAsync();
        return trackedEntity.Id;
    }

    public async Task<Guid> Delete(Guid id, Guid userId)
    {
        context.Remove(await context.Markdowns.FirstAsync(e => e.Id == id));

        await context.SaveChangesAsync();
        return id;
    }

    public async Task<List<MarkdownEntity>> Get(Guid projectId)
    {
        var result = await context.Markdowns
            .Where(e => e.ProjectId == projectId)
            .AsNoTracking()
            .ToListAsync();
        return result;
    }
}