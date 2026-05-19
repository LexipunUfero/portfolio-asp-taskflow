using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using Taskflow.Application.DTO.Project.Dasboard;
using Taskflow.Application.Interfaces.Services;

namespace Taskflow.Controllers;

[ApiController]
[Route("api/[controller]")]
public class DashboardController: ControllerBase
{
    private readonly IDashboardService service;

    public DashboardController(IDashboardService service)
    {
        this.service = service;
    }
    
    [HttpPost]
    public async Task<IActionResult> Create(DashboardCreateDTO model)
    {
        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        var result = await service.Create(model,Guid.Parse(userId));
        
        return Ok(result);
    }

    [HttpPut]
    public async Task<IActionResult> Update(DashboardUpdateDTO model)
    {
        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        var result = await service.Update(model,Guid.Parse(userId));
        
        return Ok(result);
    }
    
    [HttpGet("/api/projects/{projectId}/dashboards")]
    public async Task<IActionResult> Get(Guid id)
    {
        var result = await service.Get(id);
        
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