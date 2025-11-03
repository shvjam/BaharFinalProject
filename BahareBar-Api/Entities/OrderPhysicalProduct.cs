// File: BahareBar-Api/Entities/OrderPhysicalProduct.cs (Junction Table)
namespace BahareBar_Api.Entities;
public class OrderPhysicalProduct {
    public Guid OrderId { get; set; }
    public Order Order { get; set; }
    public Guid PhysicalProductId { get; set; }
    public PhysicalProduct PhysicalProduct { get; set; }
    public int Quantity { get; set; } // e.g., 10 boxes
}
