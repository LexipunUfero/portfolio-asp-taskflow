using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using Taskflow.Application.DTO.Task;
using Taskflow.Application.Interfaces.Services;

namespace Taskflow.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TaskController: ControllerBase
{
    private readonly ITaskService service;

    public TaskController(ITaskService service)
    {
        this.service = service;
    }
    
    [HttpGet("GetByProject/{projectId}")]
    public async Task<IActionResult> Get(Guid projectId)
    {
        var result = await service.Get(projectId);
        
        return Ok(result);
    }
    
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var result = await service.GetById(id);
        
        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> Create(TaskCreateDTO model)
    {
        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        var result = await service.Create(model,Guid.Parse(userId));
        
        return Ok(result);
    }

    [HttpPatch("Move")]
    public async Task<IActionResult> Move(TaskMoveDTO model)
    {
        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        var result = await service.Move(model,Guid.Parse(userId));
        return Ok(result);
    }
    [HttpPatch("Markdown/Attach")]
    public async Task<IActionResult> AttachMarkdown(TaskAttachMarkdown model)
    {
        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        var result = await service.AttachMarkdown(model,Guid.Parse(userId));
        return Ok(result);
    }
    
    [HttpPatch("Markdown/Deattach")]
    public async Task<IActionResult> DeattachMarkdown(TaskAttachMarkdown model)
    {
        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        var result = await service.DeattachMarkdown(model,Guid.Parse(userId));
        return Ok(result);
    }

    [HttpPatch]
    public async Task<IActionResult> Update(TaskUpdateDTO model)
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