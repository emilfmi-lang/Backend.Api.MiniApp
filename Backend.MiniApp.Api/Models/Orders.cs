using Backend.MiniApp.Api.Enums.Orders;
using Backend.MiniApp.Api.Models.Common;

namespace Backend.MiniApp.Api.Models;

public class Orders:BaseEntity
{
    public int OrderNumber { get; set; }
    public int UserId { get; set; }
    public DateTime OrderDate { get; set; }
    public decimal SubTotalAmount { get; set; }
    public decimal DiscountAmount { get; set; }
    public decimal TaxAmount { get; set; }
    public decimal TotalAmount { get; set; }
    public OrderStatus Status { get; set; }
    public PaymentStatus PaymentStatus { get; set; }
    public PaymentMethod PaymentMethod { get; set; }
    public string Note { get; set; }
    public DateTime CreatedAt { get; set; }
    public List<OrderItem> OrderItems { get; set; }

}
