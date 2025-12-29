using Backend.MiniApp.Api.Dtos.EventDtos;
using Backend.MiniApp.Api.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Backend.MiniApp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventsController(IEventService service) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetAllEvents()
        {
            var events = await service.GetAllAsync();
            return Ok(events);
        }
        [HttpPost]
        public async Task<IActionResult> CreateEvent([FromBody] EventCreateDto     eventCreateDto)
        {
            await service.CreateAsync(eventCreateDto);
            return Ok("Event created successfully");
        }
        [HttpPost("{id}/banner")]
        public async Task<IActionResult> UploadBanner(int id, [FromForm] UploadEventBannerDto dto)
        {
            await service.UploadBannerAsync(id, dto.File);
            return Ok("Banner uploaded successfully");
        }
    }
}
