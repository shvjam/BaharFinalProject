// File: BahareBar-Api/DTOs/VerifyOtpRequest.cs
using System.ComponentModel.DataAnnotations;

namespace BahareBar_Api.DTOs;

public class VerifyOtpRequest
{
    [Required]
    [Phone]
    public string PhoneNumber { get; set; }

    [Required]
    [StringLength(6, MinimumLength = 6)]
    public string Code { get; set; }
}
