using AutoMapper;
using Backend.MiniApp.Api.Data;
using Backend.MiniApp.Api.Dtos.EventDtos;
using Backend.MiniApp.Api.Dtos.Organizers;
using Backend.MiniApp.Api.Dtos.Tickets;
using Backend.MiniApp.Api.Interfaces;
using Backend.MiniApp.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace Backend.MiniApp.Api.Services;

public class EventService(AppDbContext appDbContext,IMapper mapper, IWebHostEnvironment env) : IEventService
{
    public async Task<List<EventReturnDto>> GetAllAsync()
    {
        var events = await appDbContext.Events.ToListAsync();
        var eventDtos = mapper.Map<List<EventReturnDto>>(events);
        return eventDtos;
    }
    public async Task CreateAsync(EventCreateDto eventCreateDto)
    {
        var newEvent = mapper.Map<Event>(eventCreateDto);
        await appDbContext.Events.AddAsync(newEvent);
        await appDbContext.SaveChangesAsync();
    }
    public async Task UploadBannerAsync(int eventId, IFormFile file)
    {
        var evnt = await appDbContext.Events.FindAsync(eventId);
        if (evnt == null) throw new Exception("Event not found");

        var fileName = $"{Guid.NewGuid()}{Path.GetExtension(file.FileName)}";
        var folderPath = Path.Combine(env.WebRootPath, "images", "events");
        if (!Directory.Exists(folderPath)) Directory.CreateDirectory(folderPath);

        var filePath = Path.Combine(folderPath, fileName);
        using var stream = new FileStream(filePath, FileMode.Create);
        await file.CopyToAsync(stream);

        evnt.BannerImageUrl = $"/images/events/{fileName}";
        await appDbContext.SaveChangesAsync();
    }
    public async Task<List<TicketReturnDto>> GetTicketsByEventIdAsync(int eventId)
    {
        var tickets = await appDbContext.Tickets.Where(x => x.Id == eventId).ToListAsync();
        var result = mapper.Map<List<TicketReturnDto>>(tickets);
        return result;
    }
    public async Task<OrganizerReturnDto> GetOrganizerByEventIdAsync(int eventId)
    {
        var evnt = await appDbContext.Events
            .Include(e => e.Organizer)
            .FirstOrDefaultAsync(e => e.Id == eventId);
        return mapper.Map<OrganizerReturnDto>(evnt.Organizer);
    }
    public async Task<TicketReturnDto> CreateTicketAsync(int eventId, TicketCreateDto dto)
    {
        var evnt = await appDbContext.Events.FindAsync(eventId);
        if (evnt == null) throw new Exception("Event not found");
        var ticket = mapper.Map<Ticket>(dto);
        ticket.EventId = eventId;
        await appDbContext.Tickets.AddAsync(ticket);
        await appDbContext.SaveChangesAsync();
        return mapper.Map<TicketReturnDto>(ticket);
    }
    public async Task UploadBannerrAsync(int eventId, IFormFile file)
    {
        var evnt = await appDbContext.Events.FindAsync(eventId);
        if (evnt == null)
            throw new Exception("Event not found");
        var fileName = $"{Guid.NewGuid()}{Path.GetExtension(file.FileName)}";
        var folderPath = Path.Combine(env.WebRootPath, "images", "events");
        if (!Directory.Exists(folderPath))
            Directory.CreateDirectory(folderPath);

        var filePath = Path.Combine(folderPath, fileName);
        using var stream = new FileStream(filePath, FileMode.Create);
        await file.CopyToAsync(stream);

        evnt.BannerImageUrl = $"/images/events/{fileName}";
        await appDbContext.SaveChangesAsync();
    }
}
