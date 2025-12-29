using Backend.MiniApp.Api.Dtos.EventDtos;

namespace Backend.MiniApp.Api.Interfaces;

public interface IEventService
{
    Task<List<EventReturnDto>> GetAllAsync();
    Task CreateAsync(EventCreateDto eventCreateDto);
}
