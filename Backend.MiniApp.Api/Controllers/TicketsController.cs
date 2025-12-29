using Backend.MiniApp.Api.Dtos.Tickets;
using Backend.MiniApp.Api.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Backend.MiniApp.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TicketsController(ITicketService ticketService) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAllTickets()
    {
        var tickets = await ticketService.GetAllAsync();
        return Ok(tickets);
    }
    [HttpPost]
    public async Task<IActionResult> CreateTicket([FromBody] TicketCreateDto ticketCreateDto)
    {
        await ticketService.CreateAsync(ticketCreateDto);
        return Ok("Ticket created successfully");
    }
}
