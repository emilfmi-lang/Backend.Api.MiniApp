using Backend.MiniApp.Api.Dtos.EventDtos;
using Backend.MiniApp.Api.Dtos.Tickets;
using Backend.MiniApp.Api.Interfaces;
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
        [HttpGet("{eventId}/tickets")]
        public async Task<IActionResult> GetTicketsByEvent(int eventId)
        {
            var tickets = await service.GetTicketsByEventIdAsync(eventId);
            return Ok(tickets);
        }
        [HttpGet("{eventId}/organizer")]
        public async Task<IActionResult> GetOrganizerByEvent(int eventId)
        {
            var organizer = await service.GetOrganizerByEventIdAsync(eventId);
            return Ok(organizer);
        }
        [HttpPost("{eventId}/tickets")]
        public async Task<IActionResult> CreateTicketForEvent(int eventId, [FromBody] TicketCreateDto dto)
        {
            var ticket = await service.CreateTicketAsync(eventId, dto);
            return Ok(ticket);
        }
        [HttpPost("{eventId}/banner")]
        public async Task<IActionResult> UploadBannerr(int eventId, [FromForm] UploadEventBannerDto dto)
        {
            await service.UploadBannerrAsync(eventId, dto.File);
            return Ok("Banner uploaded successfully");
        }
        [HttpDelete("{eventId}")]
        public async Task<IActionResult> DeleteEvent(int eventId)
        {
            await service.Delete(eventId);
            return Ok("Event deleted successfully");
        }
    }
}
