using Backend.MiniApp.Api.Models.Common;

namespace Backend.MiniApp.Api.Models;

public class Event : BaseEntity
{
    public string Title { get; set; }
    public string Description { get; set; }
    public DateTime Date { get; init; }
    public string Location { get; set; }
    public string BannerImageUrl { get; set; }
    public List<Ticket> Tickets { get; set; }
    public int OrganizerId { get; set; }
    public Organizer Organizer { get; set; }
    public List<EventPerformer> EventPerformers { get; set; }
}
