using Microsoft.EntityFrameworkCore;
using Taskflow.Application.Interfaces.Repositories;
using Taskflow.Domain.Entities;
using Taskflow.Infrastructure.Context;

namespace Taskflow.Infrastructure.Repositories;

public class FileRepository: IFileRepository
{
    private readonly TaskflowDbContext context;
    public FileRepository(TaskflowDbContext context)
    {
        this.context = context;
    }
    public async Task<Guid> Create(IFormFile image, string fileName, Guid? userId)
    {
        var entity = new FileEntity()
        {
            FileName = fileName,
            ContentType = image.ContentType,
            CreatedAt = DateTime.UtcNow,
            CreatedBy = userId ?? Guid.Empty,
        };
        
        await context.Files.AddAsync(entity);
        await context.SaveChangesAsync();
        return entity.Id;
    }

    public async Task<FileEntity> Get(Guid fileId)
    {
        var result = await context.Files
            .AsNoTracking()
            .FirstAsync(x => x.Id == fileId);
        return result;
    }
}