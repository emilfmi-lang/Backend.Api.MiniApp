using AutoMapper;
using Backend.MiniApp.Api.Data;
using Backend.MiniApp.Api.Dtos.EventDtos;
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
}
