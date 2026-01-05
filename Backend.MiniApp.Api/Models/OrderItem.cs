using Backend.MiniApp.Api.Enums.Orders;
using Backend.MiniApp.Api.Models.Common;

namespace Backend.MiniApp.Api.Models;

public class OrderItem:BaseEntity
{
    public int OrderId { get; set; }
    public int EventId { get; set; }
    public int TicketId { get; set; }
    public string EventTitle { get; set; }
    public string TicketName { get; set; }
    public TicketType TicketType { get; set; }
    public decimal UnitPrice { get; set; }
    public int Quantity { get; set; }
    public decimal TotalPrice { get; set; }
}
