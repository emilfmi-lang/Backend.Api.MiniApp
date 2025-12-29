using Backend.MiniApp.Api.Dtos.Organizers;
using Backend.MiniApp.Api.Interfaces;
using Backend.MiniApp.Api.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Backend.MiniApp.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class OrganizersController(IOrganizerService service) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetOrganizer()
    {
        var organizer = await service.GetAllAsync();
        return Ok(organizer);
    }
    [HttpPost]
    public async Task<IActionResult> CreateOrganizer([FromBody] OrganizerCreateDto organizerCreateDto)
    {
        await service.CreateAsync(organizerCreateDto);
        return Ok("Organizer created successfully");
    }
    [HttpPost("{id}/logo")]
    public async Task<IActionResult> UploadLogo(int id, [FromForm] UploadOrganizerLogoDto dto)
    {
        await service.UploadBannerAsync(id, dto.File);
        return Ok("Logo uploaded successfully");
    }
}
