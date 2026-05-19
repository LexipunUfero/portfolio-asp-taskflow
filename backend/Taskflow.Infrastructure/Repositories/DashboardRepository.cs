using Microsoft.EntityFrameworkCore;
using Taskflow.Application.Interfaces.Repositories;
using Taskflow.Domain.Entities;
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

    public async Task<Guid> Update(DashboardEntity entity, Guid userId)
    {
       var trackedEntity = await context.Dashboards.FirstAsync(el=>el.Id == entity.Id);

       if (trackedEntity.Index > entity.Index)
       {
            var dependentDashboards = await context.Dashboards
                .Where(el=>el.Index >= entity.Index
                && el.Index < trackedEntity.Index
                && el.ProjectId == trackedEntity.ProjectId)
                .ExecuteUpdateAsync(s => s.SetProperty(x => x.Index, x => x.Index + 1));
           
       }else if (trackedEntity.Index < entity.Index)
       {
           var dependentDashboards = await context.Dashboards
               .Where(el=>el.Index > trackedEntity.Index
                          && el.Index <= entity.Index
                          && el.ProjectId == trackedEntity.ProjectId)
               .ExecuteUpdateAsync(s => s.SetProperty(x => x.Index, x => x.Index - 1));
       }

       trackedEntity.Index = entity.Index;
       trackedEntity.Title = entity.Title;
       trackedEntity.UpdatedAt = DateTime.UtcNow;
       trackedEntity.UpdatedBy = userId;
       
       await context.SaveChangesAsync();
       
       return trackedEntity.Id;
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