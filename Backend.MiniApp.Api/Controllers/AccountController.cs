using AutoMapper;
using Backend.MiniApp.Api.Dtos.Users;
using Backend.MiniApp.Api.Interfaces;
using Backend.MiniApp.Api.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Backend.MiniApp.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AccountController(UserManager<AppUser> manager, RoleManager<IdentityRole> roleManager, IMapper mapper, IJwtService jwtService) : ControllerBase
{
    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] UserRegisterDto userRegisterDto)
    {
        var existingUser = await manager.FindByNameAsync(userRegisterDto.Username);
        if (existingUser != null)
            return BadRequest("Username is already taken.");
        var user = mapper.Map<AppUser>(userRegisterDto);
        var result = await manager.CreateAsync(user, userRegisterDto.Password);
        if (!result.Succeeded)
            return BadRequest(result.Errors);
        return Ok("Register endpoint");
    }
    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] UserLoginDto userLoginDto)
    {
        var user = await manager.FindByNameAsync(userLoginDto.Username);
        if (user == null)
            return Conflict("Invalid username or password.");
        var isPasswordValid = await manager.CheckPasswordAsync(user, userLoginDto.Password);
        if (!isPasswordValid)
            return Conflict("Invalid username or password.");
        var roles = await manager.GetRolesAsync(user);
        return Ok(jwtService.GenerateTokenAsync(user, roles));
    }
}
