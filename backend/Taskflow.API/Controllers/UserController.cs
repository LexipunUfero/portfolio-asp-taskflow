using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using Taskflow.Application.DTO.User;
using Taskflow.Application.Interfaces.Services;

namespace Taskflow.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UserController:Controller
{
    private readonly IUserService service;
    private readonly IAuthenticationService authenticationService;

    public UserController(IUserService service
    , IAuthenticationService authenticationService)
    {
        this.service = service;
        this.authenticationService = authenticationService;
    }
    
    [HttpPut]
    public async Task<IActionResult> Update(UserUpdateDTO model)
    {
        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        var result = await service.Update(model);
        
        return Ok(result);
    }
    
    [HttpPost]
    public async Task<IActionResult> UpdatePassword(UserPasswordUpdateDTO model)
    {
        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        var result = await authenticationService.Update(model,Guid.Parse(userId));
        
        return Ok(result);
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        var result = await service.Get(Guid.Parse(userId));
        
        return Ok(result); 
    }
}