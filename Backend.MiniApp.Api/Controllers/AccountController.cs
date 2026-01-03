using AutoMapper;
using Backend.MiniApp.Api.Dtos.Users;
using Backend.MiniApp.Api.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Backend.MiniApp.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AccountController(UserManager<AppUser> manager,RoleManager<IdentityRole> roleManager,IMapper mapper) : ControllerBase
{
    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody]UserRegisterDto userRegisterDto)
    {
        var existingUser = await manager.FindByNameAsync(userRegisterDto.Username);
        if(existingUser != null)
            return BadRequest("Username is already taken.");
        var user = mapper.Map<AppUser>(userRegisterDto);
        var result = await manager.CreateAsync(user, userRegisterDto.Password);
        if(!result.Succeeded)
            return BadRequest(result.Errors);
        return Ok("Register endpoint");
    }
}
