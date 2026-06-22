using Microsoft.AspNetCore.Mvc;
using Taskflow.Application.Interfaces.Services;

namespace Taskflow.Controllers;

[ApiController]
[Route("api/[controller]")]
public class FileController: ControllerBase
{
    private readonly IFileService service;

    public FileController(IFileService service)
    {
        this.service = service;
    }
    [HttpGet("{fileId}")]
    public async Task<IActionResult> Get(Guid fileId)
    {
        var result =  await service.Get(fileId);
       
        return Ok(result);
    }
}