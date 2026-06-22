using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Taskflow.Application.DTO.Markdown;
using Taskflow.Application.Interfaces.Services;

namespace Taskflow.Controllers;

[Authorize]
[ApiController]
[Route("api/[controller]")]
public class MarkdownController: ControllerBase
{
    private readonly IMarkdownService service;

    public MarkdownController(IMarkdownService service)
    {
        this.service = service;
    }
    
    [HttpPut]
    public async Task<IActionResult> Update(MarkdownUpdateDTO markdown)
    {
        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        var result = await service.Update(markdown,Guid.Parse(userId));
        
        return Ok(result);
    }
    
    [HttpPost]
    public async Task<IActionResult> Create(MarkdownCreateDTO markdown)
    {
        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        var result = await service.Create(markdown,Guid.Parse(userId));
        
        return Ok(result);
    }
    
    [HttpGet("GetByProject/{projectId}")]
    public async Task<IActionResult> Get(Guid projectId)
    {
        var result = await service.Get(projectId);
        
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