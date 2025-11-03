// File: BahareBar-Api/Entities/Order.cs
using BahareBar_Api.Entities.Base;
using BahareBar_Api.Entities.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace BahareBar_Api.Entities;

public class Order : AuditableEntity
{
    public Guid? CustomerId { get; set; } // Nullable for guest orders
    public User? Customer { get; set; }

    public Guid? DriverId { get; set; }
    public User? Driver { get; set; }

    public OrderStatus Status { get; set; }
    public DateTime OrderDate { get; set; } = DateTime.UtcNow;

    // Address Info
    public string OriginAddress { get; set; }
    public string DestinationAddress { get; set; }

    // Pricing Info
    [Column(TypeName = "decimal(18, 2)")]
    public decimal TotalPrice { get; set; }

    // Navigation Properties
    public ICollection<OrderServiceItem> OrderServiceItems { get; set; } = new List<OrderServiceItem>();
    public ICollection<OrderPhysicalProduct> OrderPhysicalProducts { get; set; } = new List<OrderPhysicalProduct>();
}
