using Backend.MiniApp.Api.Dtos.Tickets;

namespace Backend.MiniApp.Api.Interfaces;

public interface ITicketService
{
    Task<TicketReturnDto> GetAllAsync();
    Task CreateAsync(TicketCreateDto ticketCreateDto);
}
