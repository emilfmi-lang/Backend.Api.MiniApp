using AutoMapper;
using Backend.MiniApp.Api.Dtos.Users;
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
public class AccountController(UserManager<AppUser> manager, RoleManager<IdentityRole> roleManager, IMapper mapper, IConfiguration config) : ControllerBase
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
        List<Claim> claims = new()
        {
            new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
            new Claim(ClaimTypes.Name, user.UserName)
        };
        claims.AddRange(roles.Select(role => new Claim(ClaimTypes.Role, role)));
        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["JwtSettings:SecretKey"]));
        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
        var token = new JwtSecurityToken(
            issuer: config["JwtSettings : Issuer"],
            audience: config["JwtSettings : Audience"],
            claims: claims,
            expires: DateTime.Now.AddMinutes(30),
            signingCredentials: creds
        );
        var jwtToken = new JwtSecurityTokenHandler().WriteToken(token);

        return Ok(jwtToken);
    }
}
