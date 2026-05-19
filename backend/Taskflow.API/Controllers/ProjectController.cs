using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using Taskflow.Application.DTO.Project;
using Taskflow.Application.DTO.Project.Dasboard;
using Taskflow.Application.Interfaces.Services;

namespace Taskflow.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProjectController:ControllerBase
{
    IProjectService service;

    public ProjectController(IProjectService service)
    {
        this.service = service;
    }
    
    [HttpPost]
    public async Task<IActionResult> Create(ProjectCreateDTO model)
    {
        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        var result = await service.Create(model,Guid.Parse(userId));
        
        return Ok(result);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> Get(Guid id)
    {
        var result = await service.GetById(id);
        
        return Ok(result);
    }
    
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        var result = await service.Get(Guid.Parse(userId));
        
        return Ok(result);
    }
}