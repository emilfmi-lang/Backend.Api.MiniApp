using Backend.MiniApp.Api.Data;
using Backend.MiniApp.Api.Interfaces;
using Backend.MiniApp.Api.Profiles;
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
        services.AddAutoMapper(opt =>
        {
            opt.AddProfile<MapProfile>();
        }
        );
    }   
}
