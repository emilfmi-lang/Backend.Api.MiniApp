using Backend.MiniApp.Api.Dtos.EventDtos;
using Backend.MiniApp.Api.Dtos.Organizers;
using Backend.MiniApp.Api.Dtos.Tickets;

namespace Backend.MiniApp.Api.Interfaces;

public interface IEventService
{
    Task<List<EventReturnDto>> GetAllAsync();
    Task CreateAsync(EventCreateDto eventCreateDto);
    Task UploadBannerAsync(int eventId, IFormFile file);
    Task<List<TicketReturnDto>> GetTicketsByEventIdAsync(int eventId);
    Task<OrganizerReturnDto> GetOrganizerByEventIdAsync(int eventId);
    Task<TicketReturnDto> CreateTicketAsync(int eventId, TicketCreateDto dto);
    Task UploadBannerrAsync(int eventId, IFormFile file);
    Task Delete(int eventId);
}
