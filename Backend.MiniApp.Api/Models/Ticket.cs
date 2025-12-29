using Backend.MiniApp.Api.Models.Common;

namespace Backend.MiniApp.Api.Models;

public class Ticket: BaseEntity
{
    public string Type { get; set; }
    public decimal Price { get; set; }
    public int EventId { get; set; }
    public Event Event { get; set; }

}
