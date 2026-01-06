using Backend.MiniApp.Api.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Backend.MiniApp.Api.Data;

public class AppDbContext(DbContextOptions<AppDbContext> options) : IdentityDbContext<AppUser>(options)
{
    public DbSet<Event> Events { get; set; }
    public DbSet<Organizer> Organizers { get; set; }
    public DbSet<Ticket> Tickets { get; set; }
    public DbSet<Performer> Performers { get; set; }
    public DbSet<EventPerformer> EventPerformers { get; set; }
    public DbSet<Orders> Orders { get; set; }
    public DbSet<OrderItem> OrderItems { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);

        base.OnModelCreating(modelBuilder);
    }
}
