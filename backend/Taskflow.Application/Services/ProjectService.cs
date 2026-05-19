using AutoMapper;
using Microsoft.Extensions.Options;
using Taskflow.Application.DTO.Project;
using Taskflow.Application.DTO.Project.Access;
using Taskflow.Application.Interfaces.Repositories;
using Taskflow.Application.Interfaces.Services;
using Taskflow.Application.Response;
using Taskflow.Domain.Entities;
using Taskflow.Domain.Models.Configs;

namespace Taskflow.Application.Service;

public class ProjectService: IProjectService
{
    private readonly IProjectRepository repository;
    private readonly IMapper mapper;
    private readonly ProjectConfigs configs;
    private readonly IDashboardService dashboardService;
    private readonly ILogger<ProjectService> logger;
    
    public ProjectService(IProjectRepository repository,
        IDashboardService dashboardService,
        IMapper mapper,
        IOptions<ProjectConfigs> configs,
        ILogger<ProjectService> logger)
    {
        this.repository = repository;
        this.mapper = mapper;
        this.configs = configs.Value;
        this.dashboardService = dashboardService;
        this.logger = logger;
    }

    public async Task<Result<Guid>> Create(ProjectCreateDTO model, Guid userId)
    {
        var entity =  mapper.Map<ProjectEntity>(model);
        
        Guid id = await repository.Create(entity, userId);
        var dashboardResult = await dashboardService.Create(configs.DashboardConfigs, id,userId);
        
        if (!dashboardResult.IsSuccess)
        {
            logger.LogWarning("default dashboards were not created");
        }
        
        return Result<Guid>.Success(id);
    }
    
    public async Task<Result<List<ProjectGetPreviewDTO>>> Get(Guid userid)
    {
        List<ProjectEntity> entities = await repository.Get(userid);
        
        var result = entities.Select(mapper.Map<ProjectGetPreviewDTO>).ToList();
        return Result<List<ProjectGetPreviewDTO>>.Success(result);
    }

    public async Task<Result<ProjectGetDTO>> GetById(Guid id)
    {
        ProjectEntity entity = await repository.GetById(id);

        var result = mapper.Map<ProjectGetDTO>(entity);
        return Result<ProjectGetDTO>.Success(result);
    }
}