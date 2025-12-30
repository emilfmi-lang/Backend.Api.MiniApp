using Backend.MiniApp.Api.Data;
using Backend.MiniApp.Api.Interfaces;
using Backend.MiniApp.Api.Models;
using Backend.MiniApp.Api.Profiles;
using Backend.MiniApp.Api.Repositories.Concretes;
using Backend.MiniApp.Api.Repositories.Interfaces;
using Backend.MiniApp.Api.Services;
using Microsoft.EntityFrameworkCore;

namespace Backend.MiniApp.Api;

public static class ServiceRegistration
{
    public static void AddServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<AppDbContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

        services.AddScoped<IEventService, EventService>();
        services.AddScoped<IOrganizerService, OrganizerService>();
        services.AddScoped<ITicketService,TicketService >();
        services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
        services.AddAutoMapper(opt =>
        {
            opt.AddProfile<MapProfile>();
        }
        );
    }   
}
