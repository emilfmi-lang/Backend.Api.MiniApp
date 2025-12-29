using AutoMapper;
using Backend.MiniApp.Api.Dtos.EventDtos;
using Backend.MiniApp.Api.Models;

namespace Backend.MiniApp.Api.Profiles;

public class MapProfile:Profile
{
    public MapProfile()
    {
        CreateMap<Event, EventReturnDto>();
        CreateMap<EventCreateDto, Event>();
    }
}
