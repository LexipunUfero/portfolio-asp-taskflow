using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using Taskflow.Application.DTO.Project.links;
using Taskflow.Application.Interfaces.Services;

namespace Taskflow.Controllers;


[ApiController]
[Route("api/[controller]")]
public class LinkController: ControllerBase
{
    private readonly ILinkService service;

    public LinkController(ILinkService service)
    {
        this.service = service;
    }
    [HttpPost]
    public async Task<IActionResult> Get(ProjectLinkSettingsDTO model)
    {
        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        var result =  await service.Create(model,Guid.Parse(userId));
       
        return Ok(result);
    }
    [HttpPost("Join")]
    public async Task<IActionResult> Join(ProjectLinkJoinDTO model)
    {
        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        var result =  await service.Enter(model.Id,Guid.Parse(userId));
       
        return Ok(result);
    }
}