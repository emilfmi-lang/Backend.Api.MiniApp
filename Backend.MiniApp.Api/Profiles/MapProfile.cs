using AutoMapper;
using Backend.MiniApp.Api.Dtos.EventDtos;
using Backend.MiniApp.Api.Dtos.Organizers;
using Backend.MiniApp.Api.Dtos.Tickets;
using Backend.MiniApp.Api.Dtos.Users;
using Backend.MiniApp.Api.Models;

namespace Backend.MiniApp.Api.Profiles;

public class MapProfile:Profile
{
    public MapProfile()
    {
        CreateMap<Event, EventReturnDto>();
        CreateMap<EventCreateDto, Event>();
        CreateMap<Organizer, OrganizerReturnDto>();
        CreateMap<OrganizerCreateDto, Organizer>();
        CreateMap<Ticket, TicketReturnDto>();
        CreateMap<TicketCreateDto, Ticket>();
        CreateMap<UserRegisterDto, AppUser>();
    }
}
