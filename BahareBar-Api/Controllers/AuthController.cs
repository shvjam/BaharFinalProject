// File: BahareBar-Api/Controllers/AuthController.cs
using BahareBar_Api.DTOs;
using BahareBar_Api.Services;
using Microsoft.AspNetCore.Mvc;

namespace BahareBar_Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly IAuthService _authService;

    public AuthController(IAuthService authService)
    {
        _authService = authService;
    }

    [HttpPost("send-otp")]
    public async Task<IActionResult> SendOtp([FromBody] SendOtpRequest request)
    {
        var result = await _authService.SendOtpAsync(request.PhoneNumber);
        if (result)
        {
            return Ok(new { Message = "OTP sent successfully." });
        }
        return BadRequest("Failed to send OTP.");
    }

    [HttpPost("verify-otp")]
    public async Task<IActionResult> VerifyOtp([FromBody] VerifyOtpRequest request)
    {
        var authResponse = await _authService.VerifyOtpAndGenerateTokenAsync(request.PhoneNumber, request.Code);

        if (authResponse == null)
        {
            return Unauthorized(new { Message = "Invalid or expired OTP." });
        }

        return Ok(authResponse);
    }
}
