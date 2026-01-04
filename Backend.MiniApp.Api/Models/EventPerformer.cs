namespace Backend.MiniApp.Api.Models;

public class EventPerformer
{
    public int EventId { get; set; }
    public Event Event { get; set; }

    public int PerformerId { get; set; }
    public Performer Performer { get; set; }
}
