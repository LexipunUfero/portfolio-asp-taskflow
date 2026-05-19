using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using Taskflow.Application.DTO.Project.Access;
using Taskflow.Application.Interfaces.Services;

namespace Taskflow.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProjectAccessController:ControllerBase
{
    IProjectAccessService service;

    public ProjectAccessController(IProjectAccessService service)
    {
        this.service = service;
    }
    
    
    [HttpPost]
    public async Task<IActionResult> Create(ProjectAccessCreateDTO model)
    {
        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        var result = await service.Create(model,Guid.Parse(userId));
        
        return Ok(result);
    }
    [HttpGet("/api/projects/{projectId}/accesses")]
    public async Task<IActionResult> Get(Guid projectId)
    {
        var result = await service.Get(projectId);
        
        return Ok(result);
    }
    
    [HttpPut]
    public async Task<IActionResult> Update(ProjectAccessUpdateDTO model)
    {
        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        var result = await service.Update(model,Guid.Parse(userId));
        
        return Ok(result);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        var result = await service.Delete(id,Guid.Parse(userId));
        
        return Ok(result);
    }
}