using Backend.MiniApp.Api.Data;
using Backend.MiniApp.Api.Interfaces;
using Backend.MiniApp.Api.Models;
using Backend.MiniApp.Api.Profiles;
using Backend.MiniApp.Api.Repositories.Concretes;
using Backend.MiniApp.Api.Repositories.Interfaces;
using Backend.MiniApp.Api.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;

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
        services.AddScoped<IJwtService, JwtService>();
        services.AddIdentity<AppUser, IdentityRole>(opt => 
        {
            opt.Password.RequireDigit = true;
            opt.Password.RequireLowercase = true;
            opt.Password.RequireUppercase = true;
            opt.Password.RequireNonAlphanumeric = false;
            opt.Password.RequiredLength = 6;
        }).AddEntityFrameworkStores<AppDbContext>();
        services.AddAutoMapper(opt =>
        {
            opt.AddProfile<MapProfile>();
        }
        );
        services.AddAuthentication(options =>
        {
            options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        })
.AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,

        ValidIssuer = configuration["JwtSettings : Issuer"],
        ValidAudience = configuration["JwtSettings : Audience"],

        IssuerSigningKey = new SymmetricSecurityKey(
            Encoding.UTF8.GetBytes("SUPER_SECRET_KEY_123456789")
        )
    };
});
        services.AddAuthorization();
    }   
}
