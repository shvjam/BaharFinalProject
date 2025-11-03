// File: BahareBar-Api/Services/AuthService.cs
using BahareBar_Api.Data;
using BahareBar_Api.DTOs;
using BahareBar_Api.Entities;
using BahareBar_Api.Entities.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Collections.Concurrent;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace BahareBar_Api.Services;

public class AuthService : IAuthService
{
    private readonly ApplicationDbContext _context;
    private readonly ISmsService _smsService;
    private readonly IConfiguration _configuration;

    // NOTE: In a production environment, this should be a distributed cache like Redis.
    private static readonly ConcurrentDictionary<string, string> _otpCache = new();
    private static readonly ConcurrentDictionary<string, DateTime> _otpTimestampCache = new();

    public AuthService(ApplicationDbContext context, ISmsService smsService, IConfiguration configuration)
    {
        _context = context;
        _smsService = smsService;
        _configuration = configuration;
    }

    public async Task<bool> SendOtpAsync(string phoneNumber)
    {
        var otpCode = new Random().Next(100000, 999999).ToString();
        _otpCache[phoneNumber] = otpCode;
        _otpTimestampCache[phoneNumber] = DateTime.UtcNow;

        await _smsService.SendOtpAsync(phoneNumber, otpCode);
        return true;
    }

    public async Task<AuthResponse?> VerifyOtpAndGenerateTokenAsync(string phoneNumber, string code)
    {
        if (!_otpCache.TryGetValue(phoneNumber, out var storedCode) || storedCode != code)
        {
            return null; // Invalid code
        }

        if (!_otpTimestampCache.TryGetValue(phoneNumber, out var timestamp) || timestamp.AddMinutes(5) < DateTime.UtcNow)
        {
            _otpCache.TryRemove(phoneNumber, out _);
            _otpTimestampCache.TryRemove(phoneNumber, out _);
            return null; // Expired code
        }

        _otpCache.TryRemove(phoneNumber, out _);
        _otpTimestampCache.TryRemove(phoneNumber, out _);

        var user = await _context.Users.FirstOrDefaultAsync(u => u.PhoneNumber == phoneNumber);

        if (user == null)
        {
            user = new User
            {
                PhoneNumber = phoneNumber,
                Role = UserRole.Customer, // Default role for new users
                IsActive = true
            };
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
        }

        return GenerateJwtToken(user);
    }

    private AuthResponse GenerateJwtToken(User user)
    {
        var jwtSettings = _configuration.GetSection("Jwt");
        var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings["Key"]!));
        var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

        var claims = new List<Claim>
        {
            new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString()),
            new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
            new Claim(ClaimTypes.MobilePhone, user.PhoneNumber)
        };

        if (user.Role == UserRole.Admin)
        {
            claims.Add(new Claim(ClaimTypes.Role, "Admin"));
        }
        else
        {
            claims.Add(new Claim(ClaimTypes.Role, user.Role.ToString()));
        }

        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(claims),
            Expires = DateTime.UtcNow.AddDays(7),
            Issuer = jwtSettings["Issuer"],
            Audience = jwtSettings["Audience"],
            SigningCredentials = credentials
        };

        var tokenHandler = new JwtSecurityTokenHandler();
        var token = tokenHandler.CreateToken(tokenDescriptor);

        return new AuthResponse
        {
            Token = tokenHandler.WriteToken(token),
            Expiration = token.ValidTo,
            UserRole = user.Role.ToString()
        };
    }
}
