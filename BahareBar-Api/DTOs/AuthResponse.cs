// File: BahareBar-Api/DTOs/AuthResponse.cs
namespace BahareBar_Api.DTOs;

public class AuthResponse
{
    public string Token { get; set; }
    public DateTime Expiration { get; set; }
    public string UserRole { get; set; }
}
