using Microsoft.EntityFrameworkCore;
using Taskflow.Application.Interfaces.Repositories;
using Taskflow.Domain.Entities;
using Taskflow.Domain.Models.DAO;
using Taskflow.Infrastructure.Context;

namespace Taskflow.Infrastructure.Repositories;

public class DashboardRepository: IDashboardRepository
{
    private readonly TaskflowDbContext context;
    public DashboardRepository(TaskflowDbContext context)
    {
        this.context = context;
    }
    public async Task<Guid> Create(DashboardEntity entity, Guid userId)
    {
        entity.CreatedAt = DateTime.UtcNow;
        entity.CreatedBy = userId;
        await context.AddAsync(entity);
        await context.SaveChangesAsync();
        
        return entity.Id;
    }
    
    public async Task Update(List<DashboardDAO> models,Guid projectId, Guid userId)
    {
        var entities = await context.Dashboards
            .Include(el=>el.Project)
            .Where(el=>el.ProjectId == projectId)
            .ToListAsync();

        
        var modelsMap = models.Where(el=>el.Id.HasValue).ToDictionary(el => el.Id);
        foreach (var entity in entities.OrderBy(el=>el.Index).ToList())
        {
            if (!modelsMap.TryGetValue(entity.Id, out var model))
            {
                continue;
            }

            if (model.Title != null)
            {
                entity.Title = model.Title;
            }

            if (model.Index != null)
            {
                entity.Index = model.Index.Value;
            }
            
            entity.UpdatedAt = DateTime.UtcNow;
            entity.UpdatedBy = userId;
        }

        foreach (var model in models.Where(el=>el.Id is null))
        {
            var entity = new DashboardEntity()
            {
                Index = model.Index ?? 0,
                Title = model.Title ?? "Temp name",
                CreatedAt = DateTime.UtcNow,
                CreatedBy = userId,
            };
            context.Dashboards.Add(entity);

        }
        await context.SaveChangesAsync();
    }

    public async Task<List<DashboardEntity>> Get(Guid projectId)
    {
        var result = await context.Dashboards
            .Where(el=>el.ProjectId == projectId)
            .OrderBy(el=>el.Index)
            .AsNoTracking()
            .ToListAsync();
        return result;
    }

    public async Task<Guid> Delete(Guid id, Guid userId)
    {
        context.Dashboards.Remove(await context.Dashboards.FirstAsync(el=>el.Id == id));
        await context.SaveChangesAsync();
        return id;
    }
}