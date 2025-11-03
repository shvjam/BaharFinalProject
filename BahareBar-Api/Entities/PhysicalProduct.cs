// File: BahareBar-Api/Entities/PhysicalProduct.cs
using BahareBar_Api.Entities.Base;
namespace BahareBar_Api.Entities;
public class PhysicalProduct : AuditableEntity {
    public string Name { get; set; }
    public string? Description { get; set; }
    public decimal Price { get; set; }
    public int StockQuantity { get; set; }
    public string? ImageUrl { get; set; }
    public Guid ProductCategoryId { get; set; }
    public ProductCategory ProductCategory { get; set; }
}
