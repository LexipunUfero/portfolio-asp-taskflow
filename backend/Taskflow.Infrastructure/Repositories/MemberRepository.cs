using Microsoft.EntityFrameworkCore;
using Taskflow.Application.Interfaces.Repositories;
using Taskflow.Domain.Entities;
using Taskflow.Infrastructure.Context;

namespace Taskflow.Infrastructure.Repositories;

public class MemberRepository: IMemberRepository
{
    private readonly TaskflowDbContext context;
    public MemberRepository(TaskflowDbContext context)
    {
        this.context = context;
    }
    public async Task<Guid> Create(ProjectMemberEntity member)
    {
        member.CreatedAt = DateTime.UtcNow;
        await context.AddAsync(member);
        await context.SaveChangesAsync();
        
        return member.Id;
    }

    public async Task<List<ProjectMemberEntity>> Get(Guid projectId)
    {

        var result = await context.ProjectMembers
            .Where(p => p.ProjectId == projectId)
            .AsNoTracking()
            .Include(p => p.User)
            .Include(el => el.ProjectAccess)
            .ToListAsync();
        
        return result;
    }

    public async Task<Guid> Delete(Guid id, Guid userId)
    {
        context.ProjectMembers.Remove(await context.ProjectMembers.FirstAsync(p => p.Id == id));
        await context.SaveChangesAsync();
        return id;
    }

    public async Task<Guid> Update(ProjectMemberEntity entity, Guid userId)
    {
        var trackedEntity = await context.ProjectMembers
            .FirstAsync(el => el.Id == entity.Id);

        trackedEntity.ProjectAccessId = entity.ProjectAccessId;
        trackedEntity.UpdatedAt = DateTime.UtcNow;
        trackedEntity.UpdatedBy = userId;
        
        await context.SaveChangesAsync();
        return trackedEntity.Id;
    }

    public async Task<ProjectMemberEntity> GetMemberByProjectId(Guid projectId, Guid userId)
    {
       var member = await context.ProjectMembers
           .Include(project => project.Project)
           .Include(member => member.User)
           .Include(member => member.ProjectAccess)
           .Where(el => el.User.Id == userId && el.Project.Id == projectId)
           .AsNoTracking()
           .FirstOrDefaultAsync();
       
       return member;
    }
}