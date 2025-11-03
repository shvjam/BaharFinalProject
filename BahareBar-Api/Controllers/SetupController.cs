// File: BahareBar-Api/Controllers/SetupController.cs
using BahareBar_Api.Services;
using Microsoft.AspNetCore.Mvc;

namespace BahareBar_Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class SetupController : ControllerBase
{
    private readonly ISeedService _seedService;

    public SetupController(ISeedService seedService)
    {
        _seedService = seedService;
    }

    [HttpPost("seed-database")]
    public async Task<IActionResult> SeedDatabase()
    {
        await _seedService.SeedInitialDataAsync();
        return Ok("Database seeded successfully.");
    }
}
