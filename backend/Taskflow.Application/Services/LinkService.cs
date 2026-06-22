using AutoMapper;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Options;
using Taskflow.Application.DTO.Project.links;
using Taskflow.Application.Interfaces.Repositories;
using Taskflow.Application.Interfaces.Services;
using Taskflow.Application.Response;
using Taskflow.Application.Validators;
using Taskflow.Domain.Entities;
using Taskflow.Domain.Models.Configs;
using Taskflow.Domain.Models.DAO;

namespace Taskflow.Application.Service;

public class LinkService: ILinkService
{
    private readonly ILinkRepository linkRepository;
    private readonly IMapper mapper;
    private readonly LinkManager linkManager;
    private readonly ErrorMessages errorMessages;
    private readonly IMemberService memberService;
    private readonly ILogger<LinkService> logger;
    
    public LinkService(ILinkRepository linkRepository,
        IMapper mapper,
        LinkManager linkManager,
        IOptions<ErrorMessages> errorMessages,
        IMemberService memberService,
        ILogger<LinkService> logger)
    {
        this.linkRepository = linkRepository;
        this.linkManager = linkManager;
        this.mapper = mapper;
        this.errorMessages = errorMessages.Value;
        this.memberService = memberService;
        this.logger = logger;
    }
    
    public async Task<Result<string>> Create(ProjectLinkSettingsDTO model, Guid userId)
    {
        var dao = mapper.Map<ProjectMemberDAO>(model);
        var linkId = linkManager.CreateInvite(dao, model.LifeTime);

        var entity = new LinkEntity()
        {
            ProjectAccessId = dao.ProjectAccessId,
            ProjectId = dao.ProjectId,
            LifeTime =  model.LifeTime,
            Key =  linkId,
        };

        await linkRepository.Create(entity, userId);
        
        return Result<string>.Success(linkId);
    }

    public async Task<Result<Guid>> Enter(string linkId, Guid userId)
    {
        if (!linkManager.VerifyInvite(linkId))
        {
            logger.LogInformation("Incorrect invite");
            return Result<Guid>.Fail(errorMessages.InvalidLink);
        }
        
        var settings = linkManager.Get(linkId);
        Result<Guid> result = await memberService.Create(settings, userId);
        if (result.IsSuccess)
        {
            await linkRepository.AddUser(linkId, userId);
        }
        return result;
    }

}