using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Backend.MiniApp.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AccountController : ControllerBase
{
    public async Task<IActionResult> Register()
    {
        return Ok("Register endpoint");
    }
}
