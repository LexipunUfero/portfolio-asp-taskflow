using Microsoft.EntityFrameworkCore;
using Taskflow.Application.Interfaces.Repositories;
using Taskflow.Domain.Entities;
using Taskflow.Infrastructure.Context;

namespace Taskflow.Infrastructure.Repositories;

public class LinkRepository: ILinkRepository
{
    private readonly TaskflowDbContext context;
    public LinkRepository(TaskflowDbContext context)
    {
        this.context = context;
    }
    public async Task<Guid> Create(LinkEntity entity, Guid userId)
    {
        entity.CreatedAt = DateTime.UtcNow;
        entity.CreatedBy = userId;
        
        await context.AddAsync(entity);
        await context.SaveChangesAsync();
        return entity.Id;
    }

    public async Task AddUser(string linkId, Guid userId)
    {
        var entity = await context.Links
            .Where(el => el.Key == linkId)
            .OrderByDescending(el => el.CreatedAt)
            .FirstAsync();

        var linkUser = new LinkUserEntity()
        {
            LinkId = entity.Id,
            UserId = userId
        };
        
        await context.LinkUsers.AddAsync(linkUser);
    }
}