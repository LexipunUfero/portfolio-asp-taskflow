using Microsoft.EntityFrameworkCore;
using Taskflow.Application.Interfaces.Repositories;
using Taskflow.Domain.Entities;
using Taskflow.Infrastructure.Context;

namespace Taskflow.Infrastructure.Repositories;

public class CommentRepository: ICommentRepository
{
    private readonly TaskflowDbContext context;
    public CommentRepository(TaskflowDbContext context)
    {
        this.context = context;
    }
    
    public async Task<Guid> Create(string content, Guid? fileId, Guid userId)
    {
        var entity = new CommentEntity()
        {
            Content = content,
            FileId = fileId,
            CreatedBy = userId,
            CreatedAt = DateTime.UtcNow,
        };
        await context.Comments.AddAsync(entity);
        await context.SaveChangesAsync();
        return entity.Id;
    }

    public async Task<List<CommentEntity>> Get(Guid taskId)
    {
        var entities =await context.Comments
            .AsNoTracking()
            .Where(el => el.TaskId == taskId)
            .ToListAsync();
       
        return entities;
    }

    public async Task<CommentEntity> GetById(Guid id)
    {
       var entity =await context.Comments
           .AsNoTracking()
           .FirstAsync(el => el.Id == id);
       
       return entity;
    }
    
    public async Task<Guid> Update(CommentEntity entity, Guid userId)
    {
        var trackedEntity = await context.Comments.FirstAsync(el => el.Id == entity.Id);
        
        trackedEntity.FileId = entity.FileId;
        trackedEntity.Content = entity.Content;
        trackedEntity.UpdatedAt = DateTime.UtcNow;
        trackedEntity.UpdatedBy =  userId;

        await context.SaveChangesAsync();
        
        return trackedEntity.Id;
    }
    public async Task<Guid> Delete(Guid id, Guid userId)
    {
        context.Comments.Remove(await context.Comments.FirstAsync(el => el.Id == id));
        await  context.SaveChangesAsync();

        return id;
    }
}