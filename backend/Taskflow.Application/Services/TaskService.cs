using AutoMapper;
using Microsoft.Extensions.Options;
using Taskflow.Application.DTO.Task;
using Taskflow.Application.Exceptions;
using Taskflow.Application.Interfaces.Repositories;
using Taskflow.Application.Interfaces.Services;
using Taskflow.Application.Response;
using Taskflow.Domain.Entities;
using Taskflow.Domain.Models.Configs;

namespace Taskflow.Application.Service;

public class TaskService: ITaskService
{
    private readonly ITaskRepository repository;
    private readonly IMapper mapper;
    private readonly ErrorMessages errorMessages;
    private readonly ILogger<TaskService> logger;
    
    public TaskService(ITaskRepository repository,
        IOptions<ErrorMessages> errorMessages,
        IMapper mapper,
        ILogger<TaskService> logger)
    {
        this.repository = repository;
        this.mapper = mapper;
        this.errorMessages = errorMessages.Value;
        this.logger = logger;
    }

    public async Task<Result<Guid>> Create(TaskCreateDTO model, Guid userId)
    {
        var entity =  mapper.Map<TaskEntity>(model);
        Guid id = await repository.Create(entity, userId);
        
        return Result<Guid>.Success(id);
    }
    
    public async Task<Result<Guid>> Update(TaskUpdateDTO model, Guid userId)
    {
        var entity =  mapper.Map<TaskEntity>(model);
        try
        {
            Guid id = await repository.Update(entity, userId);
            return Result<Guid>.Success(id);
        }
        catch (ConcurrencyException e)
        {
            logger.LogInformation("Task was updated by other User before");
            return Result<Guid>.Fail(errorMessages.ConcurrencyError);
        }
    }
    
    public async Task<Result<List<TaskGetDTO>>> Get(Guid projectId)
    {
        List<TaskEntity> entities = await repository.Get(projectId);
        
        var result = entities.Select(mapper.Map<TaskGetDTO>).ToList();
        return Result<List<TaskGetDTO>>.Success(result);
    }
    
    public async Task<Result<TaskGetDTO>> GetById(Guid id)
    {
        TaskEntity entity = await repository.GetById(id);

        var result = mapper.Map<TaskGetDTO>(entity);
        return Result<TaskGetDTO>.Success(result);
    }
    
    public async Task<Result<Guid>> Delete(Guid id, Guid userId)
    {
        Guid resultId = await repository.Delete(id, userId);
        
        return Result<Guid>.Success(resultId);
    }

    public async Task<Result<Guid>> Move(TaskMoveDTO model, Guid userId)
    {
        Guid resultId = await repository.Move(model, userId);
        return Result<Guid>.Success(resultId);
    }

    public async Task<Result<Guid>> AttachMarkdown(TaskAttachMarkdown model, Guid userId)
    {
        Guid resultId = await repository.AttachMarkdown(model, userId);
        return Result<Guid>.Success(resultId);
    }

    public async Task<Result<Guid>> DeattachMarkdown(TaskAttachMarkdown model, Guid userId)
    {
        Guid resultId = await repository.DeattachMarkdown(model, userId);
        return Result<Guid>.Success(resultId);
    }
}