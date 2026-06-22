using AutoMapper;
using Taskflow.Application.DTO.Comments;
using Taskflow.Application.Interfaces.Repositories;
using Taskflow.Application.Interfaces.Services;
using Taskflow.Application.Response;
using Taskflow.Domain.Entities;
using Taskflow.Domain.Models.Configs;

namespace Taskflow.Application.Service;

public class CommentService: ICommentService
{
    private readonly ICommentRepository repository;
    private readonly IMapper mapper;
    private readonly IFileService fileService;
    
    public CommentService(ICommentRepository repository,
        IFileService fileService,
        IMapper mapper)
    {
        this.repository = repository;
        this.mapper = mapper;
        this.fileService = fileService;
    }

    public async Task<Result<Guid>> Create(CommentCreateDTO model, Guid userId)
    {
        Guid? fileId = null;

        if (model.Image != null)
        {
            var fileResult = await fileService.SaveImage(model.Image,userId);

            if (!fileResult.IsSuccess)
            {
                return fileResult;
            }

            fileId = fileResult.Data;
        }
        
        Guid commentId =  await repository.Create(model.TaskId,model.Content,fileId, userId);

        return Result<Guid>.Success(commentId);
    }
    
    public async Task<Result<Guid>> Update(CommentUpdateDTO model, Guid userId)
    {
        var entity = mapper.Map<CommentEntity>(model);
        
        if (model.Image != null)
        {
            Result<Guid> fileResult = await fileService.UpdateImage(model.FileId,model.Image,userId);

            if (!fileResult.IsSuccess)
            {
                return fileResult;
            }
            
            entity.FileId = fileResult.Data;
        }
        Guid id = await repository.Update(entity, userId);
        return Result<Guid>.Success(id);
    }
    
    public async Task<Result<Guid>> Delete(Guid id, Guid userId)
    {
        Guid entityId = await repository.Delete(id, userId);
        
        return Result<Guid>.Success(entityId);
    }

    public async Task<Result<List<CommentGetDTO>>> Get(Guid taskId)
    {
        List<CommentEntity> entities = await repository.Get(taskId);
        
        return Result<List<CommentGetDTO>>.Success(entities.Select(mapper.Map<CommentGetDTO>).ToList());
    }
    
}