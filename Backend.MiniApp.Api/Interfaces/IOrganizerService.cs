using Backend.MiniApp.Api.Dtos.EventDtos;
using Backend.MiniApp.Api.Dtos.Organizers;

namespace Backend.MiniApp.Api.Interfaces;

public interface IOrganizerService
{
    Task<OrganizerReturnDto> GetAllAsync();
    Task CreateAsync(OrganizerCreateDto organizerCreateDto);
    Task UploadBannerAsync(int eventId, IFormFile file);
    Task<List<EventReturnDto>> GetEventsByOrganizerIdAsync(int organizerId);
}
