using Microsoft.EntityFrameworkCore;
using Taskflow.Application.Interfaces.Repositories;
using Taskflow.Domain.Entities;
using Taskflow.Infrastructure.Context;

namespace Taskflow.Infrastructure.Repositories;

public class ProjectRepository: IProjectRepository
{
    private readonly TaskflowDbContext context;
    public ProjectRepository(TaskflowDbContext context)
    {
        this.context = context;
    }
    public async Task<Guid> Create(ProjectEntity entity, Guid userId)
    {
        entity.CreatedBy = userId;
        entity.CreatedAt = DateTime.UtcNow;
        
        var access = new ProjectAccessEntity()
        {
            Name="Owner",
            IsOwner = true,
            CanCreateTasks = true,
            CanManageUsers = true,
            CanRemoveTasks = true,
            CanUpdateTasks = true,
        };
        
        var member = new ProjectMemberEntity()
        {
            ProjectAccess = access,
            UserId = userId,
        };
        entity.ProjectAccesses = new List<ProjectAccessEntity>() { access };
        entity.ProjectMembers = new List<ProjectMemberEntity>() { member };
        await context.Projects.AddAsync(entity);
        await context.SaveChangesAsync();
        
        return entity.Id;
    }

    public async Task<List<ProjectEntity>> Get(Guid userid)
    {
        var memberIn = await context.ProjectMembers
            .AsNoTracking()
            .Where(e => e.UserId == userid)
            .Include(e => e.Project)
            .ToListAsync();
        
        var result = memberIn.Select(el => el.Project).ToList();

        return result;

    }

    public async Task<ProjectEntity> GetById(Guid id)
    {
        var project = await context.Projects
            .AsNoTracking()
            .Include(el => el.Dasboards)
            .ThenInclude(el => el.Tasks)
            .FirstAsync(el => el.Id == id);
        project.Dasboards = project.Dasboards.OrderBy(el => el.Index).ToList();
        return project;
    }
}