using AutoMapper;
using Taskflow.Application.DTO.Markdown;
using Taskflow.Application.DTO.Project.Access;
using Taskflow.Application.Interfaces.Repositories;
using Taskflow.Application.Interfaces.Services;
using Taskflow.Application.Response;
using Taskflow.Domain.Entities;

namespace Taskflow.Application.Service;

public class ProjectAccessService: IProjectAccessService
{
    private readonly IProjectAccessRepository repository;
    private readonly IMapper mapper;
    
    public ProjectAccessService(IProjectAccessRepository repository,
        IMapper mapper)
    {
        this.repository = repository;
        this.mapper = mapper;
    }

    public async Task<Result<Guid>> Create(ProjectAccessCreateDTO model, Guid userId)
    {
        var entity =  mapper.Map<ProjectAccessEntity>(model);
        Guid id = await repository.Create(entity, userId);
        
        return Result<Guid>.Success(id);
    }
    
    public async Task<Result<Guid>> Update(ProjectAccessUpdateDTO model, Guid userId)
    {
        var entity =  mapper.Map<ProjectAccessEntity>(model);
        Guid id = await repository.Update(entity, userId);
        
        return Result<Guid>.Success(id);
    }
    
    public async Task<Result<List<ProjectAccessGetDTO>>> Get(Guid projectId)
    {
        List<ProjectAccessEntity> entities = await repository.Get(projectId);
        
        var result = entities.Select(mapper.Map<ProjectAccessGetDTO>).ToList();
        return Result<List<ProjectAccessGetDTO>>.Success(result);
    }
    
    public async Task<Result<Guid>> Delete(Guid id, Guid userId)
    {
        Guid resultId = await repository.Delete(id, userId);
        
        return Result<Guid>.Success(resultId);
    }
}