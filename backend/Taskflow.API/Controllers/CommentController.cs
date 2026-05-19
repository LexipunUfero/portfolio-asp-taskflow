using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using Taskflow.Application.DTO.Comments;
using Taskflow.Application.Interfaces.Services;

namespace Taskflow.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CommentController:ControllerBase
{
    private readonly ICommentService service;

    public CommentController(ICommentService service)
    {
        this.service = service;
    }

    [HttpGet("{taskId}")]
    public async Task<IActionResult> Get(Guid taskId)
    {
       var result =  await service.Get(taskId);
       
        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> Create(CommentCreateDTO comment)
    {
        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        var result = await service.Create(comment,Guid.Parse(userId));
        
        return Ok(result);
    }

    [HttpPut]
    public async Task<IActionResult> Update(CommentUpdateDTO comment)
    {
        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        var result = await service.Update(comment,Guid.Parse(userId));
        
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