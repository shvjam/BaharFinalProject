// File: BahareBar-Api/Controllers/AdminController.cs
using BahareBar_Api.Data;
using BahareBar_Api.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BahareBar_Api.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize(Roles = "Admin")]
public class AdminController : ControllerBase
{
    private readonly ApplicationDbContext _context;

    public AdminController(ApplicationDbContext context)
    {
        _context = context;
    }

    [HttpGet("dashboard-stats")]
    public async Task<ActionResult<DashboardStatsDto>> GetDashboardStats()
    {
        var totalUsers = await _context.Users.CountAsync();
        var totalOrders = await _context.Orders.CountAsync();
        var totalRevenue = await _context.Orders.SumAsync(o => o.TotalPrice);

        var stats = new DashboardStatsDto
        {
            TotalUsers = totalUsers,
            TotalOrders = totalOrders,
            TotalRevenue = totalRevenue
        };

        return Ok(stats);
    }

    [HttpGet("recent-orders")]
    public async Task<ActionResult<IEnumerable<OrderSummaryDto>>> GetRecentOrders()
    {
        var recentOrders = await _context.Orders
            .Include(o => o.Customer) // Join with User table
            .OrderByDescending(o => o.OrderDate)
            .Take(10)
            .Select(o => new OrderSummaryDto
            {
                Id = o.Id,
                CustomerPhoneNumber = o.Customer != null ? o.Customer.PhoneNumber : "Guest",
                OrderDate = o.OrderDate,
                TotalPrice = o.TotalPrice,
                Status = o.Status.ToString()
            })
            .ToListAsync();

        return Ok(recentOrders);
    }
}
