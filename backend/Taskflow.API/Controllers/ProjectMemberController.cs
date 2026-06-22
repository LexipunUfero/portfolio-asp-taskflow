using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using Taskflow.Application.Interfaces.Services;

namespace Taskflow.Controllers;
[ApiController]
[Route("api/[controller]")]
public class ProjectMemberController: ControllerBase
{
    private readonly IMemberService service;

    public ProjectMemberController(IMemberService service)
    {
        this.service = service;
    }
    [HttpGet("{projectId}")]
    public async Task<IActionResult> Get(Guid projectId)
    {
        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        var result =  await service.GetMembers(projectId,Guid.Parse(userId));
       
        return Ok(result);
    }
}