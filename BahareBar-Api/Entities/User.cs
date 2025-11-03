// File: BahareBar-Api/Entities/User.cs
using BahareBar_Api.Entities.Base;
using BahareBar_Api.Entities.Enums;

namespace BahareBar_Api.Entities;

public class User : AuditableEntity
{
    public string PhoneNumber { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public UserRole Role { get; set; }
    public bool IsActive { get; set; } = true;

    // Navigation Property
    public ICollection<Order> Orders { get; set; } = new List<Order>();
}
