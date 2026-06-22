using AutoMapper;
using Taskflow.Application.DTO.Markdown;
using Taskflow.Application.Interfaces.Repositories;
using Taskflow.Application.Interfaces.Services;
using Taskflow.Application.Response;
using Taskflow.Domain.Entities;

namespace Taskflow.Application.Service;

public class MarkdownService: IMarkdownService
{
    private readonly IMarkdownRepository repository;
    private readonly IMapper mapper;
    
    public MarkdownService(IMarkdownRepository repository,
        IMapper mapper)
    {
        this.repository = repository;
        this.mapper = mapper;
    }

    public async Task<Result<Guid>> Create(MarkdownCreateDTO model, Guid userId)
    {
        var entity =  mapper.Map<MarkdownEntity>(model);
        Guid id = await repository.Create(entity, userId);
        
        return Result<Guid>.Success(id);
    }
    
    public async Task<Result<Guid>> Update(MarkdownUpdateDTO model, Guid userId)
    {
        var entity =  mapper.Map<MarkdownEntity>(model);
        Guid id = await repository.Update(entity, userId);
        
        return Result<Guid>.Success(id);
    }
    
    public async Task<Result<List<MarkdownGetDTO>>> Get(Guid projectId)
    {
        List<MarkdownEntity> entities = await repository.Get(projectId);
        
        var result = entities.Select(mapper.Map<MarkdownGetDTO>).ToList();
        return Result<List<MarkdownGetDTO>>.Success(result);
    }
    
    public async Task<Result<Guid>> Delete(Guid id, Guid userId)
    {
        Guid resultId = await repository.Delete(id, userId);
        
        return Result<Guid>.Success(resultId);
    }
}