// File: BahareBar-Api/Entities/OrderServiceItem.cs (Junction Table)
namespace BahareBar_Api.Entities;
public class OrderServiceItem {
    public Guid OrderId { get; set; }
    public Order Order { get; set; }
    public Guid ServiceItemId { get; set; }
    public ServiceItem ServiceItem { get; set; }
    public int Quantity { get; set; } // e.g., 3 workers, 50 meters
}
