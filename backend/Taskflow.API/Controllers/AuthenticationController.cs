using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using Taskflow.Application.DTO.Autentication;
using Taskflow.Application.Interfaces.Services;

namespace Taskflow.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthenticationController: ControllerBase
{
private readonly IAuthenticationService service;

    public AuthenticationController(IAuthenticationService service)
    {
        this.service = service;
    }
    
    [AllowAnonymous]
    [HttpPost("login")]
    public  async Task<IActionResult> Login([FromBody]LoginDTO  login)
    {
        var ip  = HttpContext.Connection.RemoteIpAddress?.ToString();
       var result =  await service.Login(login);
       
       return Ok(result);
    }
    
    [AllowAnonymous]
    [HttpPost("register")]
    public  async Task<IActionResult> Register([FromBody]RegisterDTO register)
    {
        var ip  = HttpContext.Connection.RemoteIpAddress?.ToString();
        var result =  await service.Create(register);
       
       return Ok(result);
    }
}