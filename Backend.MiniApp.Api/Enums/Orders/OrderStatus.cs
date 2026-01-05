namespace Backend.MiniApp.Api.Enums.Orders;

public enum OrderStatus
{
    Pending = 1,    // yaradılıb, ödəniş gözləyir
    Paid = 2,       // uğurla tamamlanıb
    Cancelled = 3,  // ləğv edilib
    Refunded = 4    // pul geri qaytarılıb
}
