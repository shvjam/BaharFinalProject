// File: BahareBar-Api/Services/IAuthService.cs
using BahareBar_Api.DTOs;

namespace BahareBar_Api.Services;

public interface IAuthService
{
    Task<bool> SendOtpAsync(string phoneNumber);
    Task<AuthResponse?> VerifyOtpAndGenerateTokenAsync(string phoneNumber, string code);
}
