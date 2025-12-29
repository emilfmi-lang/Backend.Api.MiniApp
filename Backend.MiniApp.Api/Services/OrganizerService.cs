using AutoMapper;
using Backend.MiniApp.Api.Data;
using Backend.MiniApp.Api.Dtos.Organizers;
using Backend.MiniApp.Api.Interfaces;
using Backend.MiniApp.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace Backend.MiniApp.Api.Services;

public class OrganizerService(AppDbContext appDbContext, IMapper mapper, IWebHostEnvironment env) :IOrganizerService
{
    public async Task<OrganizerReturnDto> GetAllAsync()
    {
        var organizer = await appDbContext.Organizers.ToListAsync();
        var organizerDto = mapper.Map<OrganizerReturnDto>(organizer);
        return organizerDto;
    }
    
    public async Task CreateAsync(OrganizerCreateDto organizerCreateDto)
    {
        var newOrganizer = mapper.Map<Organizer>(organizerCreateDto);
        await appDbContext.Organizers.AddAsync(newOrganizer);
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
