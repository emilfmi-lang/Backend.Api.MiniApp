using AutoMapper;
using Backend.MiniApp.Api.Dtos.Tickets;
using Backend.MiniApp.Api.Interfaces;
using Backend.MiniApp.Api.Models;
using Backend.MiniApp.Api.Repositories.Interfaces;

namespace Backend.MiniApp.Api.Services;

public class TicketService(IGenericRepository<Ticket> genericRepository, IMapper mapper) : ITicketService
{
    public async Task<TicketReturnDto> GetAllAsync()
    {
        var tickets = await genericRepository.GetAllAsync();
        var ticketDtos = mapper.Map<TicketReturnDto>(tickets);
        return ticketDtos;
    }
    public async Task CreateAsync(TicketCreateDto ticketCreateDto)
    {
        var newTicket = mapper.Map<Ticket>(ticketCreateDto);
        await genericRepository.AddAsync(newTicket);
        await genericRepository.SaveChangeAsync();
    }
    public async Task Delete(int id)
    {
         await genericRepository.DeleteAsync(id);
    }
}
