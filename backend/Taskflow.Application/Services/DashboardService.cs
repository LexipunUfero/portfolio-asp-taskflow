using AutoMapper;
using Taskflow.Application.DTO.Project.Access;
using Taskflow.Application.DTO.Project.Dasboard;
using Taskflow.Application.Interfaces.Repositories;
using Taskflow.Application.Interfaces.Services;
using Taskflow.Application.Response;
using Taskflow.Domain.Entities;
using Taskflow.Domain.Models.Configs;
using Taskflow.Domain.Models.DAO;

namespace Taskflow.Application.Service;

public class DashboardService:IDashboardService
{
    private readonly IDashboardRepository repository;
    private readonly IMapper mapper;
    private readonly IMemberService memberService;
    
    public DashboardService(IDashboardRepository repository,
        IMemberService memberService,
        IMapper mapper)
    {
        this.repository = repository;
        this.mapper = mapper;
        this.memberService = memberService;
    }

    public async Task<Result<Guid>> Create(DashboardCreateDTO model, Guid userId)
    {
        var entity =  mapper.Map<DashboardEntity>(model);
        Guid id = await repository.Create(entity, userId);
        
        return Result<Guid>.Success(id);
    }
    
    public async Task<Result<Guid>> Update(DashboardUpdateDTO source, Guid userId)
    {
        // var access = await memberService.CheckDashboardEditAccess(source.ProjectId, userId);
        // if (!access.IsSuccess)
        // {
        //     return Result<Guid>.Fail(access.ErrorMessage);
        // }
        var daos =  source.Dashboards.Select(mapper.Map<DashboardDAO>).ToList();
        await repository.Update(daos,source.ProjectId, userId);
        
        return Result<Guid>.Success(source.ProjectId);
    }
    
    public async Task<Result<List<DashboardGetDTO>>> Get(Guid projectId)
    {
        List<DashboardEntity> entities = await repository.Get(projectId);
        
        var result = entities.Select(mapper.Map<DashboardGetDTO>).OrderBy((el)=>el.Index).ToList();
        return Result<List<DashboardGetDTO>>.Success(result);
    }
    
    public async Task<Result<Guid>> Delete(Guid id, Guid userId)
    {
        Guid resultId = await repository.Delete(id, userId);
        
        return Result<Guid>.Success(resultId);
    }

    public async Task<Result<bool>> Create(List<DashboardConfigs> configs, Guid projectId, Guid userId)
    {
        var dashboards = configs.Select(config =>
            new DashboardEntity
            {
                ProjectId = projectId,
                Title = config.Title,
                Index = config.Index,
            });

        foreach (var dashboard in dashboards)
        {
            await repository.Create(dashboard, userId);
        }

        return Result<bool>.Success(true);
    }
}