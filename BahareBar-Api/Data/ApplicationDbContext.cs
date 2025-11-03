// File: BahareBar-Api/Data/ApplicationDbContext.cs
using BahareBar_Api.Entities;
using Microsoft.EntityFrameworkCore;

namespace BahareBar_Api.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

    public DbSet<User> Users { get; set; }
    public DbSet<ServiceCategory> ServiceCategories { get; set; }
    public DbSet<ProductCategory> ProductCategories { get; set; }
    public DbSet<ServiceItem> ServiceItems { get; set; }
    public DbSet<PhysicalProduct> PhysicalProducts { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<OrderServiceItem> OrderServiceItems { get; set; }
    public DbSet<OrderPhysicalProduct> OrderPhysicalProducts { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Configure composite primary key for OrderServiceItem
        modelBuilder.Entity<OrderServiceItem>()
            .HasKey(osi => new { osi.OrderId, osi.ServiceItemId });

        // Configure composite primary key for OrderPhysicalProduct
        modelBuilder.Entity<OrderPhysicalProduct>()
            .HasKey(opp => new { opp.OrderId, opp.PhysicalProductId });

        // Configure the relationship between User (as Customer) and Order
        modelBuilder.Entity<Order>()
            .HasOne(o => o.Customer)
            .WithMany(u => u.Orders)
            .HasForeignKey(o => o.CustomerId)
            .OnDelete(DeleteBehavior.Restrict); // Prevent deleting a user that has orders

        // Configure the relationship between User (as Driver) and Order
        modelBuilder.Entity<Order>()
            .HasOne(o => o.Driver)
            .WithMany() // A driver can have many orders, but we don't need a navigation property back from User for this
            .HasForeignKey(o => o.DriverId)
            .IsRequired(false) // A driver is not required initially
            .OnDelete(DeleteBehavior.SetNull); // If a driver is deleted, set DriverId to null
    }
}
