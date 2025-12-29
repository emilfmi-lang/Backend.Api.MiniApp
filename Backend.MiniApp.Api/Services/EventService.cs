using AutoMapper;
using Backend.MiniApp.Api.Data;
using Backend.MiniApp.Api.Dtos.EventDtos;
using Backend.MiniApp.Api.Interfaces;
using Backend.MiniApp.Api.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer.Query.Internal;

namespace Backend.MiniApp.Api.Services;

public class EventService(AppDbContext appDbContext,IMapper mapper) : IEventService
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
}
