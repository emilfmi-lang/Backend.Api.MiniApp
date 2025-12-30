using AutoMapper;
using Backend.MiniApp.Api.Data;
using Backend.MiniApp.Api.Dtos.Tickets;
using Backend.MiniApp.Api.Interfaces;
using Backend.MiniApp.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace Backend.MiniApp.Api.Services;

public class TicketService(AppDbContext appDbContext, IMapper mapper) : ITicketService
{
    public async Task<TicketReturnDto> GetAllAsync()
    {
        var tickets = await appDbContext.Tickets.ToListAsync();
        var ticketDtos = mapper.Map<TicketReturnDto>(tickets);
        return ticketDtos;
    }
    public async Task CreateAsync(TicketCreateDto ticketCreateDto)
    {
        var newTicket = mapper.Map<Ticket>(ticketCreateDto);
        await appDbContext.Tickets.AddAsync(newTicket);
        await appDbContext.SaveChangesAsync();
    }
    public async Task Delete(int id)
    {
        var ticket = await appDbContext.Tickets.FindAsync(id);
        if (ticket is null)
            throw new Exception("Ticket not found");
        appDbContext.Tickets.Remove(ticket);
        await appDbContext.SaveChangesAsync();
    }
}
