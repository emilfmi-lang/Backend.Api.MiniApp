namespace Backend.MiniApp.Api.Dtos.Tickets;

public class TicketReturnDto
{
    public string Type { get; set; }
    public decimal Price { get; set; }
    public int EventId { get; set; }
}
