// File: BahareBar-Api/Entities/ServiceItem.cs
using BahareBar_Api.Entities.Base;
namespace BahareBar_Api.Entities;
public class ServiceItem : AuditableEntity {
    public string Name { get; set; }
    public string? Description { get; set; }
    public decimal Price { get; set; }
    public string UnitOfMeasure { get; set; } // e.g., "per_item", "per_hour", "per_meter"
    public Guid ServiceCategoryId { get; set; }
    public ServiceCategory ServiceCategory { get; set; }
}
