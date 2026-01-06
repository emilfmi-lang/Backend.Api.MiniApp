using Backend.MiniApp.Api.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Backend.MiniApp.Api.Data.Configurations;

public class EventPerformerConfiguration : IEntityTypeConfiguration<EventPerformer>
{
    public void Configure(EntityTypeBuilder<EventPerformer> builder)
    {
        builder.HasKey(ep => new { ep.EventId, ep.PerformerId });
        builder.HasOne(ap => ap.Event)
               .WithMany(a => a.EventPerformers)
               .HasForeignKey(ap => ap.EventId)
               .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(ap => ap.Performer)
               .WithMany(p => p.EventPerformers)
               .HasForeignKey(ap => ap.PerformerId)
               .OnDelete(DeleteBehavior.Cascade);
    }
}
