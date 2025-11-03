// File: BahareBar-Api/Services/ConsoleSmsService.cs
namespace BahareBar_Api.Services;

public class ConsoleSmsService : ISmsService
{
    private readonly ILogger<ConsoleSmsService> _logger;

    public ConsoleSmsService(ILogger<ConsoleSmsService> logger)
    {
        _logger = logger;
    }

    public Task SendOtpAsync(string phoneNumber, string otpCode)
    {
        // In a real application, this would use an SMS gateway.
        // For development, we just log it to the console.
        _logger.LogInformation("---- OTP Code for {PhoneNumber}: {OtpCode} ----", phoneNumber, otpCode);
        return Task.CompletedTask;
    }
}
