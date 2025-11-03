// File: BahareBar-Api/Services/ISmsService.cs
namespace BahareBar_Api.Services;

public interface ISmsService
{
    Task SendOtpAsync(string phoneNumber, string otpCode);
}
